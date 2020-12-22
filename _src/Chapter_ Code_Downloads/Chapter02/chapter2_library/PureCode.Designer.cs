using System;
using System.Workflow.Activities;

namespace chapter2_library
{
	public sealed partial class PureCode
	{
		#region Designer generated code
		
		private void InitializeComponent()
		{
         this.CanModifyActivities = true;
         this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
         // 
         // codeActivity1
         // 
         this.codeActivity1.Name = "codeActivity1";
         this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
         // 
         // PureCode
         // 
         this.Activities.Add(this.codeActivity1);
         this.Name = "PureCode";
         this.CanModifyActivities = false;

		}

		#endregion

      private CodeActivity codeActivity1;


   }
}
