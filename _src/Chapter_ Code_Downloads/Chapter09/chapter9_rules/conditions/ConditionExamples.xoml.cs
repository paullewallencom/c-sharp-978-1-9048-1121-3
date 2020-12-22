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
	public partial class ConditionExamples : SequentialWorkflowActivity
	{

    int x;
    string name;
    int[] numbers = { 1, 2, 3 };

    bool CheckIndex()
    {
      return true;
    }

    int GetResult()
    {
      x = 0;
      name = "Scott";
      numbers[0]++;

      return 1;
    }

	}
}
