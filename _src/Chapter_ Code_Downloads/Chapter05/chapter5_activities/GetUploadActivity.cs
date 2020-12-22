using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace chapter5_activities
{
    
	public partial class GetUploadActivity: SequenceActivity
	{
		public GetUploadActivity()
		{
			InitializeComponent();
		}

        public static DependencyProperty UserNameProperty = 
            DependencyProperty.Register(
                    "UserName", 
                    typeof(System.String), 
                    typeof(GetUploadActivity));

        [DesignerSerializationVisibilityAttribute(
            DesignerSerializationVisibility.Visible)]
        [BrowsableAttribute(true)]
        [CategoryAttribute("Parameters")]
        public String UserName
        {
            get
            {
                return ((string)(base.GetValue(GetUploadActivity.UserNameProperty)));
            }
            set
            {
                base.SetValue(GetUploadActivity.UserNameProperty, value);
            }
        }

        private void requestUpload_MethodInvoking(object sender, EventArgs e)
        {
            uploadID = this.WorkflowInstanceId;
        }

        public Guid uploadID = Guid.Empty;
	}
}
