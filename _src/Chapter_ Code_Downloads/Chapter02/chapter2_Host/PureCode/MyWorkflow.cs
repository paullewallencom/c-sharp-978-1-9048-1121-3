using System;
using System.Workflow.Activities;
using OdeToCode.WinWF.Activities;

namespace PureCode
{
   public class MyWorkflow : SequentialWorkflowActivity
   {
      public MyWorkflow()
      {
         WriteLineActivity activity;
         activity = new WriteLineActivity();
         activity.Message = "Hello, Workflow";

         this.Activities.Add(activity);         
      }
   }
}
