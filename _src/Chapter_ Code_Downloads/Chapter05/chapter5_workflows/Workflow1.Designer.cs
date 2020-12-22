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

namespace chapter5_workflows
{
	partial class Workflow1
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
            this.getUploadActivity1 = new chapter5_activities.GetUploadActivity();
            // 
            // getUploadActivity1
            // 
            this.getUploadActivity1.Name = "getUploadActivity1";
            this.getUploadActivity1.UserName = null;
            // 
            // Workflow1
            // 
            this.Activities.Add(this.getUploadActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private chapter5_activities.GetUploadActivity getUploadActivity1;
	}
}
