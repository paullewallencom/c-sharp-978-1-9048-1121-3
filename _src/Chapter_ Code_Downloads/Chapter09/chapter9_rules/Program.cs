#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using chapter9_rules.conditions;
using chapter9_rules.cag;
using chapter9_rules.policy;

#endregion

namespace chapter9_rules
{
    class Program
    {
        static void Main(string[] args)
        {
          //BugLoopingDriver.Run();
          //CagDriver.RunBasic();
          //ActivationDriver.Run();
          //BugScoringDriver.Run();
          BugScoringDriver.RunWithTracking();
          //BugScoringDriver.RunWithDynamicUpdates();
        }
    }
}
