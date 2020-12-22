using System;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Serialization;

[assembly: XmlnsDefinition(
      "http://schemas.OdeToCode.com/WinWF/Activities", 
      "OdeToCode.WinWF.Activities")
]

namespace OdeToCode.WinWF.Activities
{
   public class WriteLineActivity : Activity
   {
      protected override ActivityExecutionStatus Execute
               (ActivityExecutionContext executionContext)
      {
         Console.WriteLine(_message);
         return ActivityExecutionStatus.Closed;
      }

      private string _message;
      public string Message
      {
         get { return _message; }
         set { _message = value; }
      }
   }
}
