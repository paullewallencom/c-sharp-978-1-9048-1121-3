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

namespace chapter3_sequential
{
	public partial class BugFlow : SequentialWorkflowActivity
	{
        public chapter3.BugAddedArgs _newBug;
        public chapter3.Bug _bugToAssign;
    
        private void CallAssignBug_MethodInvoking(object sender, EventArgs e)
        {
            _bugToAssign = _newBug.NewBug;
        }
    }
}
