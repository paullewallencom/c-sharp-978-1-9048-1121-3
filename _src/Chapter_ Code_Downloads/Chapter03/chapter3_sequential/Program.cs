#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using chapter3_sequential.Properties;
using System.Diagnostics;
using System.Workflow.Activities;
using chapter3;

#endregion

namespace chapter3_sequential
{
    class Program
    {
        static AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            //RunWorkflow1();
            RunBugFlow();
            //RunWorkflowEvents();
            //RunWorkflowParameters();
            //RunWorkflowWithoutParameters();
            //RunWorkflowFault();
        }

        private static void RunWorkflow1()
        {
            Console.WriteLine("Running Workflow1");

            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowAborted +=
                   new EventHandler<WorkflowEventArgs>(runtime_WorkflowAborted);

            runtime.WorkflowCompleted +=
               new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
            runtime.WorkflowCreated +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowCreated);
            runtime.WorkflowIdled +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowIdled);
            runtime.WorkflowLoaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowLoaded);
            runtime.WorkflowPersisted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowPersisted);
            runtime.WorkflowResumed +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowResumed);
            runtime.WorkflowStarted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowStarted);
            runtime.WorkflowSuspended +=
               new EventHandler<WorkflowSuspendedEventArgs>(runtime_WorkflowSuspended);
            runtime.WorkflowTerminated +=
               new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);
            runtime.WorkflowUnloaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowUnloaded);

            runtime.StartRuntime();

            WorkflowInstance instance;
            instance = runtime.CreateWorkflow(typeof(Workflow1));
            instance.Start();
            waitHandle.WaitOne();
            runtime.StopRuntime();        
        }

        private static void RunWorkflowFault()
        {
            Console.WriteLine("Running WorkflowFault:");

            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowAborted +=
                   new EventHandler<WorkflowEventArgs>(runtime_WorkflowAborted);

            runtime.WorkflowCompleted +=
               new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
            runtime.WorkflowCreated +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowCreated);
            runtime.WorkflowIdled +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowIdled);
            runtime.WorkflowLoaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowLoaded);
            runtime.WorkflowPersisted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowPersisted);
            runtime.WorkflowResumed +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowResumed);
            runtime.WorkflowStarted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowStarted);
            runtime.WorkflowSuspended +=
               new EventHandler<WorkflowSuspendedEventArgs>(runtime_WorkflowSuspended);
            runtime.WorkflowTerminated +=
               new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);
            runtime.WorkflowUnloaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowUnloaded);

            runtime.StartRuntime();

            WorkflowInstance instance;
            instance = runtime.CreateWorkflow(typeof(WorkflowFault));
            instance.Start();
            waitHandle.WaitOne();
            runtime.StopRuntime();        
        }

        private static void RunWorkflowWithoutParameters()
        {
            Console.WriteLine("Running WorkflowParameters");

            WorkflowInstance instance;
            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
            runtime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);

            instance = runtime.CreateWorkflow(typeof(WorkflowParameters));
            instance.Start();
            waitHandle.WaitOne();
            runtime.StopRuntime();
        }

        private static void RunWorkflowParameters()
        {
            Console.WriteLine("Running WorkflowParameters");

            WorkflowInstance instance;
            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
            runtime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FirstName", "Scott");
            parameters.Add("LastName", "Allen");

            instance = runtime.CreateWorkflow(typeof(WorkflowParameters), parameters);
            instance.Start();
            waitHandle.WaitOne();
            runtime.StopRuntime();
        }

        static void RunWorkflowEvents()
        {
            Console.WriteLine("Running WorkflowEvents:");

            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowAborted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowAborted);
            runtime.WorkflowCompleted +=
               new EventHandler<WorkflowCompletedEventArgs>(runtime_WorkflowCompleted);
            runtime.WorkflowCreated +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowCreated);
            runtime.WorkflowIdled +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowIdled);
            runtime.WorkflowLoaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowLoaded);
            runtime.WorkflowPersisted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowPersisted);
            runtime.WorkflowResumed +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowResumed);
            runtime.WorkflowStarted +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowStarted);
            runtime.WorkflowSuspended +=
               new EventHandler<WorkflowSuspendedEventArgs>(runtime_WorkflowSuspended);
            runtime.WorkflowTerminated +=
               new EventHandler<WorkflowTerminatedEventArgs>(runtime_WorkflowTerminated);
            runtime.WorkflowUnloaded +=
               new EventHandler<WorkflowEventArgs>(runtime_WorkflowUnloaded);

            runtime.StartRuntime();

            WorkflowInstance instance;
            instance = runtime.CreateWorkflow(typeof(WorkflowEvents));
            instance.Start();
            waitHandle.WaitOne();
            runtime.StopRuntime();
        }

        private static void RunBugFlow()
        {
            Console.WriteLine("Running BugFlow");

            WorkflowRuntime runtime = new WorkflowRuntime();

            runtime.WorkflowCompleted +=
                new EventHandler<WorkflowCompletedEventArgs>(
                     runtime_WorkflowCompleted);

            runtime.WorkflowTerminated +=
                new EventHandler<WorkflowTerminatedEventArgs>(
                     runtime_WorkflowTerminated);

            ExternalDataExchangeService dataService;
            dataService = new ExternalDataExchangeService();
            runtime.AddService(dataService);

            BugFlowService bugFlow = new BugFlowService();
            dataService.AddService(bugFlow);

            WorkflowInstance instance;
            instance = runtime.CreateWorkflow(typeof(BugFlow));
            instance.Start();

            Bug bug = new Bug(1, "Bug Title", "Bug Description");
            bugFlow.CreateBug(instance.InstanceId, bug);

            waitHandle.WaitOne();
            runtime.StopRuntime();
        }

        static void runtime_WorkflowUnloaded(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow unloaded");
        }

        static void runtime_WorkflowTerminated(object sender,
                                               WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine("Workflow terminated");
            Console.WriteLine("\tException: " + e.Exception.Message);
            waitHandle.Set();
        }

        static void runtime_WorkflowSuspended(object sender,
                                              WorkflowSuspendedEventArgs e)
        {
            Console.WriteLine("Workflow suspended");
            Console.WriteLine("\tReason: " + e.Error);
            e.WorkflowInstance.Resume();
        }
        static void runtime_WorkflowStarted(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow started");
        }

        static void runtime_WorkflowResumed(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow resumed");
        }

        static void runtime_WorkflowPersisted(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow persisted");
        }

        static void runtime_WorkflowLoaded(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow loaded");
        }

        static void runtime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow idled");
        }

        static void runtime_WorkflowCreated(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow created");
        }

        static void runtime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("Workflow completed");
            Console.WriteLine("\tOutput parameters: ");
            foreach (KeyValuePair<string, object> pair in e.OutputParameters)
            {
                Console.WriteLine("\t\tName: {0} Value: {1}", pair.Key, pair.Value);
            }
            waitHandle.Set();
        }

        static void runtime_WorkflowAborted(object sender, WorkflowEventArgs e)
        {            
            Console.WriteLine("Workflow aborted");
            waitHandle.Set();
        }
    }
}
