#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime.Configuration;
using System.Configuration;

#endregion

namespace chapter7_statemachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleRun();
            InspectingRun();
        }

        static void SimpleRun()
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += 
                   delegate 
                   { 
                       waitHandle.Set(); 
                   };

                workflowRuntime.WorkflowTerminated +=
                   delegate
                   {
                       Console.WriteLine("Exception!");
                                waitHandle.Set(); 
                   };

                ExternalDataExchangeService dataExchange;
                dataExchange = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataExchange);

                BugService bugService = new BugService();
                dataExchange.AddService(bugService);
                

                WorkflowInstance instance;
                instance = workflowRuntime.CreateWorkflow(
                                    typeof(BugFlow)
                                 );
                instance.Start();

                Bug bug = new Bug();
                bug.Title = "Application crash while printing";

                bugService.OpenBug(instance.InstanceId, bug);
                bugService.DeferBug(instance.InstanceId, bug);
                bugService.AssignBug(instance.InstanceId, bug);
                bugService.ResolveBug(instance.InstanceId, bug);
                bugService.CloseBug(instance.InstanceId, bug);

                waitHandle.WaitOne();
            }
        }

        static void InspectingRun()
        {
            using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted +=
                   delegate
                   {
                       waitHandle.Set();
                   };

                workflowRuntime.WorkflowTerminated +=
                   delegate
                   {
                       Console.WriteLine("Exception!");
                       waitHandle.Set();
                   };

                SqlTrackingService trackingService;
                trackingService = new SqlTrackingService(
                            ConfigurationManager.
                            ConnectionStrings["WorkflowDB"].
                            ConnectionString);
                trackingService.UseDefaultProfile = true;
                workflowRuntime.AddService(trackingService);

                SqlWorkflowPersistenceService persistenceService;
                persistenceService = new SqlWorkflowPersistenceService(
                            ConfigurationManager.
                            ConnectionStrings["WorkflowDB"].
                            ConnectionString, true, TimeSpan.MaxValue, TimeSpan.MinValue);
                workflowRuntime.AddService(persistenceService);


                ExternalDataExchangeService dataExchange;
                dataExchange = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataExchange);

                BugService bugService = new BugService();
                dataExchange.AddService(bugService);


                WorkflowInstance instance;
                instance = workflowRuntime.CreateWorkflow(
                                    typeof(BugFlow)
                                 );
                instance.Start();

                Bug bug = new Bug();
                bug.Title = "Application crash while printing";

                bugService.OpenBug(instance.InstanceId, bug);
                bugService.DeferBug(instance.InstanceId, bug);
                bugService.AssignBug(instance.InstanceId, bug);
                
                DumpStateMachine(workflowRuntime, instance.InstanceId);
                
                bugService.ResolveBug(instance.InstanceId, bug);
                DumpHistory(workflowRuntime, instance.InstanceId);
                bugService.CloseBug(instance.InstanceId, bug);
                
                waitHandle.WaitOne();
                
            }
        }

        private static void DumpStateMachine(
                                WorkflowRuntime runtime,
                                Guid instanceID)
        {
            StateMachineWorkflowInstance instance =             
                    new StateMachineWorkflowInstance(
                            runtime, instanceID);

            Console.WriteLine("Workflow ID: {0}", instanceID);
            Console.WriteLine("Current State: {0}", 
                              instance.CurrentStateName);
            Console.WriteLine("Possible Transitions: {0}",
                             instance.PossibleStateTransitions.Count);
            foreach (string name in instance.PossibleStateTransitions)
            {
                Console.WriteLine("\t{0}", name);
            }
        }

        private static void DumpHistory(
                                WorkflowRuntime runtime,
                                Guid instanceID)
        {
            StateMachineWorkflowInstance instance =
                    new StateMachineWorkflowInstance(
                            runtime, instanceID);

            Console.WriteLine("State History:");
            foreach (string name in instance.StateHistory)
            {
                Console.WriteLine("\t{0}", name);
            }
        }
    }
}
