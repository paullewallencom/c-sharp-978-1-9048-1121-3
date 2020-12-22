using System;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using chapter8_Communication;
using System.Collections.ObjectModel;

public static class Drivers
{
   public static void RunBugFlow()
   {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
         {
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
            workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
            {
               Console.WriteLine(e.Exception.Message);
               waitHandle.Set();
            };

            ExternalDataExchangeService dataService = new ExternalDataExchangeService();
            workflowRuntime.AddService(dataService);

            IBugVotingService bugService = new BugVotingService();
            dataService.AddService(bugService);


            WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugFlow));
            instance.Start();

            waitHandle.WaitOne();
         }
   }

   public static void RunBugFlowWithRoles()
   {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
         AutoResetEvent waitHandle = new AutoResetEvent(false);
         workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
         workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
         {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
         };

         ExternalDataExchangeService dataService = new ExternalDataExchangeService();
         workflowRuntime.AddService(dataService);

         IBugVotingService bugService = new BugVotingService();
         dataService.AddService(bugService);


         WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugFlowWithRoles));
         instance.Start();

         waitHandle.WaitOne();
      }
   }

   public static void RunBugFlowAndDumpQueues()
   {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
         AutoResetEvent waitHandle = new AutoResetEvent(false);
         workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
         workflowRuntime.WorkflowIdled += delegate(object sender, WorkflowEventArgs e) { DumpQueueInfo(e.WorkflowInstance); };
         workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
         {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
         };

         ExternalDataExchangeService dataService = new ExternalDataExchangeService();
         workflowRuntime.AddService(dataService);

         IBugVotingService bugService = new BugVotingService();
         dataService.AddService(bugService);


         WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugFlow));
         instance.Start();

         waitHandle.WaitOne();
      }
   }

   public static void RunHelloWorldClient()
   {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
         AutoResetEvent waitHandle = new AutoResetEvent(false);
         workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
         workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
         {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
         };

         WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(HelloWorldClient));
         instance.Start();

         waitHandle.WaitOne();
      }
   }


   public static void RunBugFlowAndCancel()
   {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
         AutoResetEvent waitHandle = new AutoResetEvent(false);
         workflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { waitHandle.Set(); };
         workflowRuntime.WorkflowIdled += delegate(object sender, WorkflowEventArgs e) { CancelBugFlow(e.WorkflowInstance); };
         workflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e)
         {
            Console.WriteLine(e.Exception.Message);
            waitHandle.Set();
         };

         ExternalDataExchangeService dataService = new ExternalDataExchangeService();
         workflowRuntime.AddService(dataService);

         IBugVotingService bugService = new BugVotingService();
         dataService.AddService(bugService);


         WorkflowInstance instance = workflowRuntime.CreateWorkflow(typeof(BugFlow));
         instance.Start();

         waitHandle.WaitOne();
      }
   }

   private static void CancelBugFlow(WorkflowInstance workflowInstance)
   {
      ReadOnlyCollection<WorkflowQueueInfo> queueInfos;
      queueInfos = workflowInstance.GetWorkflowQueueData();

      foreach (WorkflowQueueInfo queueInfo in queueInfos)
      {        
         workflowInstance.EnqueueItem(
               queueInfo.QueueName,
               new Exception(),
               null,
               null
            );
      }
   }


   static void DumpQueueInfo(WorkflowInstance workflow)
   {
      ReadOnlyCollection<WorkflowQueueInfo> queueInfos;
      queueInfos = workflow.GetWorkflowQueueData();


      Console.WriteLine("Queue Info for {0}", workflow.InstanceId);

      for (int i = 0; i < queueInfos.Count; i++)
      {
         Console.WriteLine();
         Console.WriteLine("Queue #{0}", i.ToString());
         Console.WriteLine(queueInfos[i].QueueName);
         Console.Write("Subscribed activities: ");

         ReadOnlyCollection<string> names = queueInfos[i].SubscribedActivityNames;
         foreach (string name in names)
         {
            Console.Write("{0} ", name);
         }
         Console.WriteLine(); 
         Console.WriteLine();         
      }
   }
}