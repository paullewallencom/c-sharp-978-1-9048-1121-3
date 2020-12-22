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

namespace Chapter8_WebService
{
   public sealed partial class HelloWorldWorkflow : 
            SequentialWorkflowActivity
   {
      public HelloWorldWorkflow()
      {
         InitializeComponent();
      }

      public string _name = String.Empty;
      public string _result;

      private void SendingOutput(object sender, EventArgs e)
      {
         _result = String.Format(
                  "Hello World! Hello, {0}!",
                  _name);
      }
   }
}
