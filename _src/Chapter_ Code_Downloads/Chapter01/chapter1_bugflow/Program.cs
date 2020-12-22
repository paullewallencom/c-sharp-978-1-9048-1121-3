using System;
using System.Workflow.Runtime;
using System.Threading;

namespace chapter1_bugflow
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowRuntime workflowRuntime = new WorkflowRuntime();           
         
            workflowRuntime.WorkflowCompleted += 
               new EventHandler<WorkflowCompletedEventArgs>
                  (workflowRuntime_WorkflowCompleted);

            workflowRuntime.WorkflowTerminated += 
               new EventHandler<WorkflowTerminatedEventArgs>
                  (workflowRuntime_WorkflowTerminated);
               
            WorkflowInstance instance;
            instance = workflowRuntime.CreateWorkflow(typeof(Workflow1));
            instance.Start();

            waitHandle.WaitOne();
        }

       static void workflowRuntime_WorkflowTerminated(object sender, 
                                      WorkflowTerminatedEventArgs e)
       {
          Console.WriteLine(e.Exception.Message);
          waitHandle.Set();          
       }

       static void workflowRuntime_WorkflowCompleted(object sender, 
                                       WorkflowCompletedEventArgs e)
       {
          waitHandle.Set();     
       }

       static AutoResetEvent waitHandle = new AutoResetEvent(false);
    }
}
