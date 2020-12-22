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

namespace chapter7_statemachine
{
	public partial class BugFlowHierarchy : StateMachineWorkflowActivity
	{
        Bug _bug;

        private void handleBugEvent_Invoked(object sender, ExternalDataEventArgs e)
        {
            _bug = ((BugStateChangedEventArgs)e).Bug;
        }
    }

}
