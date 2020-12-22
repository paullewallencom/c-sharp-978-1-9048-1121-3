#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using chapter4_bal.events;

#endregion

namespace chapter4_bal
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {                
                ExternalDataExchangeService dataService = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataService);

                BugFlowService bugService = new BugFlowService();
                dataService.AddService(bugService);

                workflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(workflowRuntime_WorkflowTerminated);
                workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
                workflowRuntime.WorkflowIdled += new EventHandler<WorkflowEventArgs>(workflowRuntime_WorkflowIdled);

                AutoResetEvent waitHandle = new AutoResetEvent(false);

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugWorkflow));
                instance.Start();                

                Console.ReadLine();
            }
        }

        static void workflowRuntime_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            Console.WriteLine("Workflow idled: " + e.WorkflowInstance.InstanceId);
        }

        static void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.WriteLine("Workflow completed: " + e.WorkflowDefinition.Name);
        }

        static void workflowRuntime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        {
            Console.WriteLine("Workflow terminated: " + e.Exception.Message);
        }
    }
}
