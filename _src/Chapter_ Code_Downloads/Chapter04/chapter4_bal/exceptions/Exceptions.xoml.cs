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

namespace chapter4_bal.exceptions
{
	public partial class Exceptions : SequentialWorkflowActivity
	{
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Caught an exception in " + this.Parent.Name);
        }
    }
}
