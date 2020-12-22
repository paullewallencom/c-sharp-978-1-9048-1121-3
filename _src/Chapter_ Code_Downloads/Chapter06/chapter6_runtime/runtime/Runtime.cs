using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Diagnostics;
using System.Net;

namespace chapter6_runtime
{
	class RuntimeFeatures
	{
        public static void Run()
        {
            TraceListener console;
            console = new TextWriterTraceListener(Console.Out, "console");
            Trace.Listeners.Add(console);
            
            using(WorkflowRuntime runtime = new WorkflowRuntime())
            using(AutoResetEvent reset = new AutoResetEvent(false))
            {
                runtime.WorkflowCompleted += delegate { reset.Set(); };
                runtime.WorkflowTerminated += delegate { reset.Set(); };
                runtime.StartRuntime();

                WorkflowInstance instance;
                instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                instance.Start();
                reset.WaitOne();
            }

            Trace.Listeners.Remove("console");
        }

        public static void RunWithConfig()
        {
            using(WorkflowRuntime runtime = new WorkflowRuntime("WorkflowRuntime"))
            using(AutoResetEvent reset = new AutoResetEvent(false))
            {
                runtime.WorkflowCompleted += delegate { reset.Set(); };
                runtime.WorkflowTerminated += delegate { reset.Set(); };
                runtime.StartRuntime();

                WorkflowInstance instance;
                instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                instance.Start();
                reset.WaitOne();
            }
            
        }
	}
}
