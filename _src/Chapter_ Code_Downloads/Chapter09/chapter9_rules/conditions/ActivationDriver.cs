using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Xml;
using System.Collections.Generic;

namespace chapter9_rules.conditions
{
  class ActivationDriver
  {
    public static void Run()
    {
      using (WorkflowRuntime workflowRuntime = new WorkflowRuntime())
      {
        AutoResetEvent waitHandle = new AutoResetEvent(false);
        workflowRuntime.WorkflowCompleted += delegate { waitHandle.Set(); };
        workflowRuntime.WorkflowTerminated += delegate { Console.WriteLine("exception!"); waitHandle.Set(); };

        XmlReader definitionReader;
        definitionReader = XmlReader.Create(@"..\..\conditions\Activation.xoml");

        XmlReader rulesReader;
        rulesReader = XmlReader.Create(@"..\..\conditions\Activation.rules");

        Dictionary<string, object> parameters = null;
        WorkflowInstance instance;
        instance = workflowRuntime.CreateWorkflow(
                                    definitionReader, rulesReader, parameters
                                   );

        instance.Start();
        waitHandle.WaitOne();
      }
    }
  }
}
