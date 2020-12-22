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
using Otc.Workflow.Services;

namespace chapter9_rules.conditions
{
  public partial class BugLooping : SequentialWorkflowActivity
  {

    private Bug[] _bugs;
    private int bugIndex = 0;

    protected void CheckBugIndex(object sender, ConditionalEventArgs e)
    {
      if (_bugs == null || bugIndex >= _bugs.Length)
      {
        e.Result = false;
      }
      else
      {
        e.Result = true;
      }
    }

    private void codeActivity1_ExecuteCode(object sender, EventArgs e)
    {
      Console.WriteLine(_bugs[bugIndex].Title);
      bugIndex++;
    }


    public Bug[] Bugs
    {
      set { _bugs = value; }
    }

    

  }
}
