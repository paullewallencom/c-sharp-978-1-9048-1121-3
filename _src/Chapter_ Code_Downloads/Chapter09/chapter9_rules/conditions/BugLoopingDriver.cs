using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Collections.Generic;
using Otc.Workflow.Services;

namespace chapter9_rules.conditions
{
  public static class BugLoopingDriver
  {
    public static void Run()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        workflowRuntime.WorkflowCompleted += delegate { waitHandle.Set(); };
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        Dictionary<string, object> parameters = CreateParameters();        
        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugLooping), parameters);
        instance.Start();

        waitHandle.WaitOne();
      }
    }

    private static Dictionary<string, object> CreateParameters()
    {
      Dictionary<string, object> result;
      result = new Dictionary<string, object>();

      Bug[] bugs = new Bug[10];
      for (int i = 0; i < bugs.Length; i++)
      {
        bugs[i] = new Bug(i, "Bug " + i.ToString(), String.Empty);        
      }

      result.Add("Bugs", bugs);
      return result;
    }
  }
}