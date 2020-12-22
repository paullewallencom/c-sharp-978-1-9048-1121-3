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
using System.Security.Principal;

namespace chapter8_Communication
{
	public partial class BugFlowWithRoles : SequentialWorkflowActivity
	{
      public WorkflowRoleCollection validRoles = 
                  new WorkflowRoleCollection();

      private void BugFlowWithRoles_Initialized(object sender, EventArgs e)
      {
         validRoles.Add(new WebWorkflowRole("TechLeads"));               
      }      
   }
}
