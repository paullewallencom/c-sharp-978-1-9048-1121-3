using System;
using System.Workflow.Activities;

namespace chapter1_bugflow
{
	public partial class Workflow1 : SequentialWorkflowActivity
	{
      private bool _isFixed;
      public bool IsFixed
      {
         get { return _isFixed; }
         set { _isFixed = value; }
      }

      private void codeActivity1_ExecuteCode(object sender, EventArgs e)
      {
         Console.WriteLine("Is the bug fixed?");
         
         Char answer = Console.ReadKey().KeyChar;
         answer = Char.ToLower(answer);

         if (answer == 'y')
         {
            _isFixed = true;
         }
         else
         {
            Console.WriteLine();
            Console.WriteLine("Get back to work!");
            Console.WriteLine();
         }
      }	
	}
}
