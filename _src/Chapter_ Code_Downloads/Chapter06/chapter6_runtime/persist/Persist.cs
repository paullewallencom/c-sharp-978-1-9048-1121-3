using System;
using System.Workflow.Runtime;
using System.Threading;
using chapter6_runtime.persist;
using System.Workflow.Runtime.Hosting;
using System.Collections.ObjectModel;

namespace chapter6_runtime
{
  public class Persist
  {
    public static void Run()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowWithPersistence"))
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

  public class PersistSerialization
  {
    public static void Run()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowWithPersistence"))
      using (AutoResetEvent reset =
        new AutoResetEvent(false))
      {

        runtime.WorkflowCompleted += delegate { reset.Set(); };
        runtime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
                                      {
                                        Console.WriteLine(e.Exception.Message);
                                        reset.Set();
                                      };

        runtime.WorkflowPersisted +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowPersisted);
        runtime.WorkflowLoaded +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowLoaded);
        runtime.WorkflowUnloaded +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowUnloaded);
        runtime.WorkflowIdled +=
          new EventHandler<WorkflowEventArgs>(runtime_WorkflowIdled);

        WorkflowInstance instance;
        instance = runtime.CreateWorkflow(typeof(WorkflowWithDelay2));
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
