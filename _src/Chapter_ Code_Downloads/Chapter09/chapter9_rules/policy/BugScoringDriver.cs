using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Collections.Generic;
using System.Workflow.Activities.Rules;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime.Configuration;
using System.Configuration;
using System.Workflow.ComponentModel;
using System.CodeDom;

namespace chapter9_rules.policy
{
  class BugScoringDriver
  {

    static AutoResetEvent waitHandle = new AutoResetEvent(false);
    public static void Run()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {

        workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        BugDetails bug = new BugDetails();
        bug.Title = "Major crash and burn";
        bug.IsOpenedByClient = false;
        bug.IsSecurityRelated = true;
        bug.Priority = BugPriority.Medium;

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Bug", bug);

        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugScoring), parameters);
        instance.Start();

        waitHandle.WaitOne();
      }
    }

    public static void RunWithTracking()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime("WorkflowWithTracking"))
      {

        workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        BugDetails bug = new BugDetails();
        bug.Title = "Major crash and burn";
        bug.IsOpenedByClient = false;
        bug.IsSecurityRelated = true;
        bug.Priority = BugPriority.Medium;

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Bug", bug);

        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugScoring), parameters);
        instance.Start();

        waitHandle.WaitOne();

        DumpRuleTrackingEvents(instance.InstanceId);

      }
    }

    private static void DumpRuleTrackingEvents(Guid instanceId)
    {
      WorkflowRuntimeSection config;
      config = ConfigurationManager.GetSection("WorkflowWithTracking")
               as WorkflowRuntimeSection;

      SqlTrackingQuery sqlTrackingQuery = new SqlTrackingQuery();
      sqlTrackingQuery.ConnectionString =
        config.CommonParameters["ConnectionString"].Value;

      SqlTrackingWorkflowInstance sqlTrackingWorkflowInstance;

      if (sqlTrackingQuery.TryGetWorkflow(
                  instanceId, out sqlTrackingWorkflowInstance))
      {

        Console.WriteLine("{0,-10} {1,-22} {2,-17}",
                          "Time", "Rule", "Condition Result");

        foreach (UserTrackingRecord userTrackingRecord in
                 sqlTrackingWorkflowInstance.UserEvents)
        {
          RuleActionTrackingEvent ruleActionTrackingEvent =
            userTrackingRecord.UserData as RuleActionTrackingEvent;

          if (ruleActionTrackingEvent != null)
          {
            Console.WriteLine("{0,-10} {1,-24} {2,-17}",
                            userTrackingRecord.EventDateTime.ToShortTimeString(),
                            ruleActionTrackingEvent.RuleName.ToString(),
                            ruleActionTrackingEvent.ConditionResult.ToString());
          }
        }
      }
    }

    static void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
    {
      int score = (int)e.OutputParameters["Score"];
      Console.WriteLine("Workflow complete, score = {0}", score);
      waitHandle.Set();
    }

    public static void RunWithDynamicUpdates()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {

        workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        BugDetails bug = new BugDetails();
        bug.Title = "Major crash and burn";
        bug.IsOpenedByClient = false;
        bug.IsSecurityRelated = true;
        bug.Priority = BugPriority.Medium;

        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("Bug", bug);

        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugScoring), parameters);

        ModifyWorkflow(instance);

        instance.Start();

        waitHandle.WaitOne();

      }
    }

    private static void ModifyWorkflow(WorkflowInstance instance)
    {
      Activity workflowDefinition = instance.GetWorkflowDefinition();

      WorkflowChanges workflowchanges;
      workflowchanges = new WorkflowChanges(workflowDefinition);
      CompositeActivity transient = workflowchanges.TransientWorkflow;

      RuleDefinitions ruleDefinitions = (RuleDefinitions)transient.GetValue(
            RuleDefinitions.RuleDefinitionsProperty
        );

      RuleSet ruleSet = ruleDefinitions.RuleSets["BugScoring"];
      foreach (Rule rule in ruleSet.Rules)
      {
        if (rule.Name == "AdjustBugPriorityForSecurity")
        {
          rule.Active = false;
        }

        if (rule.Name == "NotificationRule")
        {
          RuleExpressionCondition condition;
          condition = rule.Condition as RuleExpressionCondition;

          CodeBinaryOperatorExpression expression;
          expression = condition.Expression as CodeBinaryOperatorExpression;
          expression.Right = new CodePrimitiveExpression(120);
        }        
      }
      instance.ApplyWorkflowChanges(workflowchanges);
    }
  }
}
