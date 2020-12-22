#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using BugTrackingServices;

#endregion

namespace chapter5_workflows
{
    class Program
    {
        static void Main(string[] args)
        {
            using(WorkflowRuntime workflowRuntime = new WorkflowRuntime())
            {
                AutoResetEvent waitHandle = new AutoResetEvent(false);
                workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) {waitHandle.Set();};
                workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                {
                    Console.WriteLine(e.Exception.Message);
                    waitHandle.Set();
                };

                ExternalDataExchangeService dataExchange = new ExternalDataExchangeService();
                workflowRuntime.AddService(dataExchange);
                BugFlowService bugService = new BugFlowService();
                dataExchange.AddService(bugService);
                

                WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(chapter5_workflows.Workflow4));
                instance.Start();

                waitHandle.WaitOne();
            }
        }
    }
}
