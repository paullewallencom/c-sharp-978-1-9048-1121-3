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

namespace chapter9_rules.conditions
{
	public partial class BugNotification : SequentialWorkflowActivity
	{
    private void codeActivity1_ExecuteCode(object sender, EventArgs e)
    {
      if (_random == null)
        _random = new Random();

      if (_random.Next(100) < 30)
      {
        _notificationSent = true;
        Console.WriteLine("Notification Sent!");
      }
      else
      {
        _notificationSent = false;
        Console.WriteLine("Notification not sent!");
      }

      if (!_notificationSent)
        _retryCount++;
    }

    [NonSerialized]
    Random _random = null;

    int _retryCount = 0;
    bool _notificationSent = false;
	}
}
