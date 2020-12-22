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
using System.Collections.Generic;

namespace chapter6_runtime.persist
{
	public partial class WorkflowWithDelay2 : SequentialWorkflowActivity
	{
       
    Bug _bug = new Bug();
	}

  //[NonSerialized]

  class Bug
  {
    private Guid _id;
    public Guid BugID
    {
      get { return _id; }
      set { _id = value; }
    }
  }

  //[Serializable]
  //class Bug
  //{
  //  private Guid _id;
  //  public Guid BugID
  //  {
  //    get { return _id; }
  //    set { _id = value; }
  //  }
  //}

}
