using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace chapter5_activities
{
	public partial class GetUploadActivity
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
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding1 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding2 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.WorkflowParameterBinding workflowparameterbinding3 = new System.Workflow.ComponentModel.WorkflowParameterBinding();
            this.waitForUploadCompleted = new System.Workflow.Activities.HandleExternalEventActivity();
            this.requestUpload = new System.Workflow.Activities.CallExternalMethodActivity();
            // 
            // waitForUploadCompleted
            // 
            this.waitForUploadCompleted.EventName = "UploadCompleted";
            this.waitForUploadCompleted.InterfaceType = typeof(Otc.Workflow.Services.IBugService);
            this.waitForUploadCompleted.Name = "waitForUploadCompleted";
            workflowparameterbinding1.ParameterName = "e";
            this.waitForUploadCompleted.ParameterBindings.Add(workflowparameterbinding1);
            // 
            // requestUpload
            // 
            this.requestUpload.InterfaceType = typeof(Otc.Workflow.Services.IBugService);
            this.requestUpload.MethodName = "RequestUpload";
            this.requestUpload.Name = "requestUpload";
            activitybind1.Name = "GetUploadActivity";
            activitybind1.Path = "UserName";
            workflowparameterbinding2.ParameterName = "userName";
            workflowparameterbinding2.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            activitybind2.Name = "GetUploadActivity";
            activitybind2.Path = "uploadID";
            workflowparameterbinding3.ParameterName = "id";
            workflowparameterbinding3.SetBinding(System.Workflow.ComponentModel.WorkflowParameterBinding.ValueProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.requestUpload.ParameterBindings.Add(workflowparameterbinding2);
            this.requestUpload.ParameterBindings.Add(workflowparameterbinding3);
            this.requestUpload.MethodInvoking += new System.EventHandler(this.requestUpload_MethodInvoking);
            // 
            // GetUploadActivity
            // 
            this.Activities.Add(this.requestUpload);
            this.Activities.Add(this.waitForUploadCompleted);
            this.Name = "GetUploadActivity";
            this.CanModifyActivities = false;

		}

		#endregion

        private HandleExternalEventActivity waitForUploadCompleted;
        private CallExternalMethodActivity requestUpload;










    }
}
