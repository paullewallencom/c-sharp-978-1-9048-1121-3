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

namespace chapter9_rules.cag
{
	public partial class BasicCag : SequentialWorkflowActivity
	{
    int count = 2;

    private void codeActivity_ExecuteCode(object sender, EventArgs e)
    {
      count++;
      CodeActivity activity = sender as CodeActivity;
      Console.WriteLine("Inside of {0} : {1}", activity.QualifiedName, count);
      
    }
  }
}
