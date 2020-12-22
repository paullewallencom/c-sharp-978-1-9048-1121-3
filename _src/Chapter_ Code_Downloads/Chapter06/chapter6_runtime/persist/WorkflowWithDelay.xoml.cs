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

namespace chapter6_runtime
{
  public partial class WorkflowWithDelay : SequentialWorkflowActivity
  {
    private void codeActivity_ExecuteCode(object sender, EventArgs e)
    {
      CodeActivity activity = sender as CodeActivity;
      Console.WriteLine("Hello from {0}", activity.Name);
    }
  }
}
