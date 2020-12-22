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

namespace chapter4_bal
{
	public partial class BasicActivities : SequentialWorkflowActivity
	{
        public Exception throwActivity1_Fault1 = new System.Exception();
    
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {            
            Console.WriteLine("Great sales!");
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Mediocre sales!");
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            Sales -= 1000;
        }

        private void checkSalesAmount(object sender, ConditionalEventArgs e)
        {
            e.Result = Sales > 5000;
        }

        private double _sales;
        public double Sales
        {
            get { return _sales; }
            set { _sales = value; }
        }

        private void codeActivity4_ExecuteCode(object sender, EventArgs e)
        {
            
        }
    }
}
