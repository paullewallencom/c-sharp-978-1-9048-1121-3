#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Net;
using System.IO;
using chapter6_runtime.tracking;
using chapter6_runtime.ultimate;

#endregion

namespace chapter6_runtime
{
  class Program
  {
    static void Main(string[] args)
    {

      // DependencyProperty.Register("PropertyName", typeof(ActivityCondition), typeof(ConditionedActivityGroup), new PropertyMetadata(DependencyPropertyOptions.Metadata));
      //RuntimeFeatures.Run();
      //RuntimeFeatures.RunWithConfig();
      //Persist.Run();
      //PersistSerialization.Run();
      //Schedulers.RunDefault();
      //Schedulers.RunManual();
      //Schedulers.RunManualWithConfig();    
      //Schedulers.RunImperative();
      //Schedulers.RunDeclarative();

      //Tracking.RunSimple();
      //CustomTracking.Run();

      Ultimate.Run();

    }
  }
}
