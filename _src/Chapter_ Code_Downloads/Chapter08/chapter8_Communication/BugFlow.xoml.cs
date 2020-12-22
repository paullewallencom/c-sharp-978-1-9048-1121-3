using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace chapter8_Communication
{
	public partial class BugFlow : SequentialWorkflowActivity
	{

      private void HandleVoteCompleted_Invoked(object sender, ExternalDataEventArgs e)
      {
         VoteCompletedEventArgs voteArgs = e as VoteCompletedEventArgs;
         Console.WriteLine("Tech lead ({0}) voted", voteArgs.UserName);
      }

      private void HandleVoteCompleted2_Invoked(object sender, ExternalDataEventArgs e)
      {
         VoteCompletedEventArgs voteArgs = e as VoteCompletedEventArgs;
         Console.WriteLine("Analyst ({0}) voted", voteArgs.UserName);
      }
   }
}
