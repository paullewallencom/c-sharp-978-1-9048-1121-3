using System;
using System.Workflow.Activities;

namespace chapter3_sequential
{
    public partial class WorkflowParameters : SequentialWorkflowActivity
    {
        public string FirstName
        {
            set { _firstName = value; }
        }
        private string _firstName;

        public string LastName
        {
            set { _lastName = value; }
        }
        private string _lastName;

        public string FullName
        {
            get { return _fullName; }
        }
        private string _fullName;

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            _fullName = String.Format("{0} {1}", _firstName, _lastName);
        }

        // ...

        private void CheckFirstAndLastName(object sender, ConditionalEventArgs e)
        {
            if (!String.IsNullOrEmpty(_firstName) &&
                !String.IsNullOrEmpty(_lastName))
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }
        }
    }
}
