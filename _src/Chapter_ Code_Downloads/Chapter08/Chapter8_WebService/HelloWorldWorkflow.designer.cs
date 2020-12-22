using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Chapter8_WebService
{
	partial class HelloWorldWorkflow
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
         this.CanModifyActivities = true;
         System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
         System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
         System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
         System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
         this.webServiceOutputActivity1 = new System.Workflow.Activities.WebServiceOutputActivity();
         this.helloWorldRequest = new System.Workflow.Activities.WebServiceInputActivity();
         // 
         // webServiceOutputActivity1
         // 
         this.webServiceOutputActivity1.InputActivityName = "helloWorldRequest";
         this.webServiceOutputActivity1.Name = "webServiceOutputActivity1";
         activitybind1.Name = "HelloWorldWorkflow";
         activitybind1.Path = "_result";
         workflowparameterbinding1.ParameterName = "(ReturnValue)";
         workflowparameterbinding1.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
         this.webServiceOutputActivity1.ParameterBindings.Add(workflowparameterbinding1);
         this.webServiceOutputActivity1.SendingOutput += new System.EventHandler(this.SendingOutput);
         // 
         // helloWorldRequest
         // 
         this.helloWorldRequest.InterfaceType = typeof(Chapter8_WebService.IHelloWorldService);
         this.helloWorldRequest.IsActivating = true;
         this.helloWorldRequest.MethodName = "GetHelloWorldMessage";
         this.helloWorldRequest.Name = "helloWorldRequest";
         activitybind2.Name = "HelloWorldWorkflow";
         activitybind2.Path = "_name";
         workflowparameterbinding2.ParameterName = "name";
         workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
         this.helloWorldRequest.ParameterBindings.Add(workflowparameterbinding2);
         // 
         // HelloWorldWorkflow
         // 
         this.Activities.Add(this.helloWorldRequest);
         this.Activities.Add(this.webServiceOutputActivity1);
         this.Name = "HelloWorldWorkflow";
         this.CanModifyActivities = false;

		}

		#endregion

      private WebServiceOutputActivity webServiceOutputActivity1;
      private WebServiceInputActivity helloWorldRequest;





   }
}
