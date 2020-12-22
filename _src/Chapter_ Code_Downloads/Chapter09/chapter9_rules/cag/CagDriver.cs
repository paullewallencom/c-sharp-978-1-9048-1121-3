using System;
using System.Workflow.Runtime;
using System.Threading;

namespace chapter9_rules.cag
{
  public static class CagDriver
	{
    static public void RunBasic()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        workflowRuntime.WorkflowCompleted += delegate { waitHandle.Set(); };
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };
        
        WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BasicCag));
        instance.Start();

        waitHandle.WaitOne();
      }
    }
	}
}
