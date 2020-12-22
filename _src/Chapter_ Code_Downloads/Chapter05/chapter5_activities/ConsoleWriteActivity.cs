using System;
using System.Workflow.ComponentModel;
using System.ComponentModel;
using System.Workflow.ComponentModel.Compiler;

namespace OdeToCode.WF.CustomActivities
{  
    [ActivityValidator(typeof(ConsoleWriteValidator))]
    [Designer(typeof(ConsoleWriteDesigner))]
    public class ConsoleWriteActivity : Activity
    {        
        [DefaultValue("")]
        [Description("The text to write to the console")]
        [Category("Activity")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _text;

        protected override ActivityExecutionStatus Execute(
            ActivityExecutionContext executionContext)
        {
            Console.WriteLine(Text);
            return ActivityExecutionStatus.Closed;
        }
    }
}