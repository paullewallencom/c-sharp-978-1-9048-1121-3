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

namespace chapter9_rules.policy
{
	public partial class BugScoring : SequentialWorkflowActivity
	{

    public void SendNotification()
    {
      Console.WriteLine("Notification sent!");
    }

    //[RuleWrite("Bug/Priority")]
    //public void AdjustBugForSecurity()
    //{
    //  // .. other work

    //  Bug.Priority = BugPriority.High;

    //  // .. other work
    //}

    [RuleInvoke("SetBugPriorityHigh")]
    public void AdjustBugForSecurity()
    {
      // .. other work

      SetBugPriorityHigh();

      // .. other work
    }
    
    [RuleWrite("Bug/Priority")]
    void SetBugPriorityHigh()
    {
      Bug.Priority = BugPriority.High;
    }



    private BugDetails _bug;
    public BugDetails Bug
    {
      get { return _bug; }
      set { _bug = value; }
    }
	
    private int _score;
    public int Score
    {
      get { return _score; }
      set { _score = value; }
    }	
	}
}
