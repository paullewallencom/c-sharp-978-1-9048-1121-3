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

namespace chapter4_bal.events
{
	public partial class BugWorkflow : SequentialWorkflowActivity
	{
        public Guid id;
        public string userName;
        public string filename;
        public bool uploadRequested;

        private void callExternalMethodActivity1_MethodInvoking(
            object sender, EventArgs e)
        {
            id = this.WorkflowInstanceId;
            userName = "Scott";

        }

        private void handleExternalEventActivity1_Invoked(object sender, ExternalDataEventArgs e)
        {

        }
    }
}
