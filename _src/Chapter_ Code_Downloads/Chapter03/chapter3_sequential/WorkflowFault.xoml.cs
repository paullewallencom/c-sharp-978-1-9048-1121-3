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
	public partial class WorkflowFault : SequentialWorkflowActivity
	{
        public Exception fault;
    
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Going to throw an exception...");
            int y = 0;
            int x = 5 / y;
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.Write("Inside the exception handler");
        }
    }
}
