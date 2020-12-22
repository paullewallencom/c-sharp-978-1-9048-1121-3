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

namespace chapter8_Communication
{
	public partial class HelloWorldClient : 
            SequentialWorkflowActivity
	{
      public string _helloWorldResult;

      private void invokeHelloWorld_Invoked(
            object sender, 
            InvokeWebServiceEventArgs e)
      {
         Console.WriteLine("Hello world returned " + 
                           _helloWorldResult);
      }
   }
}
