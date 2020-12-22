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
	public partial class Workflow1 : SequentialWorkflowActivity
	{
        int counter = 0;

        private void IncrementCounter_ExecuteCode(object sender, EventArgs e)
        {
            counter++;
        }

        private void WriteCounter_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("The value of counter is {0}.", counter);
        }

        private void CheckCounter(object sender, ConditionalEventArgs e)
        {
            e.Result = false;
            if (counter < 10)
            {
                e.Result = true;
            }
        }
	}
}
