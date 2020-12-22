#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;

#endregion

namespace chapter8_Communication
{
   class Program
   {
      static void Main(string[] args)
      {
         //Drivers.RunBugFlow();
         //Drivers.RunBugFlowWithRoles();
         //Drivers.RunBugFlowAndDumpQueues();
         //Drivers.RunBugFlowAndCancel();
         Drivers.RunHelloWorldClient();

      }
   }
}
