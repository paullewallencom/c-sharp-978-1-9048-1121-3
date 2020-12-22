using OdeToCode.WinWF.Activities;
using System.Workflow.Activities;

namespace ReSerialize {

public partial class MyWorkflow : SequentialWorkflowActivity
{  
    private WriteLineActivity writeLineActivity1;
    
    public MyWorkflow()
    {
        this.InitializeComponent();
    }

   private void InitializeComponent()
    {
        this.CanModifyActivities = true;
        
        this.writeLineActivity1 = new WriteLineActivity();       
        this.writeLineActivity1.Message = "Hello, workflow!";        
        this.writeLineActivity1.Name = "writeLineActivity1";
        this.Activities.Add(this.writeLineActivity1);
        this.Name = "MyWorkflow";

        this.CanModifyActivities = false;
    }
}

}