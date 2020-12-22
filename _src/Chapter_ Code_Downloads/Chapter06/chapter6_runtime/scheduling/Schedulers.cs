using System;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Runtime;
using System.Threading;


namespace chapter6_runtime
{
    class Schedulers
    {

        public static void RunDeclarative()
        {
            WorkflowRuntime runtime1 = new WorkflowRuntime("ManualRuntime");
            WorkflowRuntime runtime2 = new WorkflowRuntime("DefaultRuntime");

            WorkflowInstance instance;
            instance = runtime1.CreateWorkflow(typeof(SimpleWorkflow));

            Console.WriteLine("Setting up workflow from thread {0}",
                Thread.CurrentThread.ManagedThreadId);

            instance.Start();

            ManualWorkflowSchedulerService scheduler;
            scheduler = runtime1.GetService<ManualWorkflowSchedulerService>();
            scheduler.RunWorkflow(instance.InstanceId);

            instance = runtime2.CreateWorkflow(typeof(SimpleWorkflow));
            instance.Start();


            Thread.Sleep(5000);

            runtime1.StopRuntime();
            runtime2.StopRuntime();
            runtime1.Dispose(); runtime2.Dispose();
        }

        public static void RunImperative()
        {
            WorkflowRuntime runtime1 = new WorkflowRuntime();
            WorkflowRuntime runtime2 = new WorkflowRuntime();

            ManualWorkflowSchedulerService scheduler;
            scheduler = new ManualWorkflowSchedulerService();
            runtime1.AddService(scheduler);

            WorkflowInstance instance;
            instance = runtime1.CreateWorkflow(typeof(SimpleWorkflow));

            Console.WriteLine("Setting up workflow from thread {0}",
                Thread.CurrentThread.ManagedThreadId);

            instance.Start();
            scheduler.RunWorkflow(instance.InstanceId);

            instance = runtime2.CreateWorkflow(typeof(SimpleWorkflow));
            instance.Start();

            Thread.Sleep(5000);

            runtime1.StopRuntime();
            runtime2.StopRuntime();
            runtime1.Dispose(); runtime2.Dispose();
        }

        public static void RunDefault()
        {
            using (WorkflowRuntime runtime = new WorkflowRuntime())
            using (AutoResetEvent reset = new AutoResetEvent(false))
            {
                runtime.WorkflowCompleted += delegate { reset.Set(); };
                runtime.WorkflowTerminated += delegate { reset.Set(); };

                DefaultWorkflowSchedulerService scheduler;
                scheduler = new DefaultWorkflowSchedulerService();
                runtime.AddService(scheduler);

                WorkflowInstance instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                Console.WriteLine("Calling instance.Start() in Thread {0}",
                                  Thread.CurrentThread.ManagedThreadId);

                instance.Start();
                reset.WaitOne();
            }
        }

        public static void RunManual()
        {
            using (WorkflowRuntime runtime = new WorkflowRuntime())
            {
                ManualWorkflowSchedulerService scheduler;
                scheduler = new ManualWorkflowSchedulerService();
                runtime.AddService(scheduler);

                WorkflowInstance instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                Console.WriteLine("Calling instance.Start() in Thread {0}",
                                  Thread.CurrentThread.ManagedThreadId);

                instance.Start();
                scheduler.RunWorkflow(instance.InstanceId);
            }
        }

        public static void RunManualWithConfig()
        {
            using (WorkflowRuntime runtime = new WorkflowRuntime("WorkflowRuntime"))
            {
                WorkflowInstance instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
                Console.WriteLine("Calling instance.Start() in Thread {0}",
                                  Thread.CurrentThread.ManagedThreadId);

                instance.Start();


                ManualWorkflowSchedulerService scheduler = runtime.GetService<ManualWorkflowSchedulerService>();
                scheduler.RunWorkflow(instance.InstanceId);
            }
        }
    }
}
