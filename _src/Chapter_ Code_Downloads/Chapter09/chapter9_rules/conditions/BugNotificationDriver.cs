using System;
using System.Workflow.Runtime;
using System.Threading;


namespace chapter9_rules.conditions
{
  public static class BugNotificationDriver
  {
    public static void Run()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        workflowRuntime.WorkflowCompleted += delegate { waitHandle.Set(); };
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugNotification));
        instance.Start();

        waitHandle.WaitOne();
      }
    }
  }
}
