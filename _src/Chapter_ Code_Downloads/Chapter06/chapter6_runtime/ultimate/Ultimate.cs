using System;
using System.Workflow.Runtime;
using System.Threading;


namespace chapter6_runtime.ultimate
{
  class Ultimate
  {
    public static void Run()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowConfiguration"))
      using (AutoResetEvent reset =
        new AutoResetEvent(false))
      {

        runtime.WorkflowCompleted += delegate { reset.Set(); };
        runtime.WorkflowTerminated += delegate { reset.Set(); };
        runtime.WorkflowAborted += delegate { reset.Set(); };

        runtime.WorkflowPersisted +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowPersisted);
        runtime.WorkflowLoaded +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowLoaded);
        runtime.WorkflowUnloaded +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowUnloaded);
        runtime.WorkflowIdled +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowIdled);

        WorkflowInstance instance;
        instance = runtime.CreateWorkflow(typeof(WorkflowWithDelay));
        instance.Start();
        reset.WaitOne();
      }
    }

    static void runtime_WorkflowIdled(object sender, WorkflowEventArgs e)
    {
      Console.WriteLine("Workflow {0} idled",
                        e.WorkflowInstance.InstanceId);
    }

    static void runtime_WorkflowUnloaded(object sender, WorkflowEventArgs e)
    {
      Console.WriteLine("Workflow {0} unloaded",
                        e.WorkflowInstance.InstanceId);
    }

    static void runtime_WorkflowLoaded(object sender, WorkflowEventArgs e)
    {
      Console.WriteLine("Workflow {0} loaded",
                        e.WorkflowInstance.InstanceId);
    }

    static void runtime_WorkflowPersisted(object sender, WorkflowEventArgs e)
    {
      Console.WriteLine("Workflow {0} persisted",
                      e.WorkflowInstance.InstanceId);
    }
  }
}
