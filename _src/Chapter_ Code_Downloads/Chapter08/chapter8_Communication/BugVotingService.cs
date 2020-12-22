using System;
using System.Workflow.Activities;
using System.Workflow.Runtime;
using System.Threading;
using System.Collections.ObjectModel;

namespace chapter8_Communication
{
   [ExternalDataExchange]
   [CorrelationParameter("userName")]
   public interface IBugVotingService
   {
      [CorrelationAlias("userName", "e.UserName")]
      event EventHandler<VoteCompletedEventArgs> VoteCompleted;

      [CorrelationInitializer]
      void RequestVote(string userName);
   }

   [Serializable]
   public class VoteCompletedEventArgs : ExternalDataEventArgs
   {
      public VoteCompletedEventArgs(
                                 Guid instanceId,
                                 string userName,
                                 bool isYesVote)
         : base(instanceId)
      {
         _userName = userName;
         _isYesVote = isYesVote;
      }

      private string _userName;
      public string UserName
      {
         get { return _userName; }
         set { _userName = value; }
      }


      private bool _isYesVote;
      public bool IsYesVote
      {
         get { return _isYesVote; }
         set { _isYesVote = value; }
      }
   }

   public class BugVotingService : IBugVotingService
   {
      public event EventHandler<VoteCompletedEventArgs> VoteCompleted;

      public void RequestVote(string userName)
      {
         Console.WriteLine("The workflow requested a vote from '{0}'.", userName);

         VoteCompletedEventArgs args;
         args = new VoteCompletedEventArgs(
                  WorkflowEnvironment.WorkflowInstanceId,
                  userName,
                  false);
         args.WaitForIdle = true;

         ThreadPool.QueueUserWorkItem(new WaitCallback(SendVoteResults), args);

      }    

      private void SendVoteResults(object state)
      {
         VoteCompletedEventArgs args = state as VoteCompletedEventArgs;

         Thread.Sleep(1000);

         if (args.UserName.Contains("Sue"))
         {
            Thread.Sleep(3000);
         }
 
         EventHandler<VoteCompletedEventArgs> eh = VoteCompleted;
         if (eh != null)
         {            
            eh(null, args);
         }
      }

   }
   
   //// uncorrelated
   //[ExternalDataExchange]
   //public interface IBugVotingService
   //{
   //   void RequestVote(string userName);
   //   event EventHandler<VoteCompletedEventArgs> VoteCompleted;
   //}
}
