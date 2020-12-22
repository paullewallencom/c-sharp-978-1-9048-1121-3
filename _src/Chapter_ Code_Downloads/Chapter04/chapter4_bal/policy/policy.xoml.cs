using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace chapter4_bal.policy
{
	public partial class policy : SequentialWorkflowActivity
	{
        Applicant applicant = null;
        int score = 0;


	}

    public class Applicant
    {
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int ComputeSalaryTrend()
        {
            return 0;
        }

        private int _salary;

        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        private int _timesLAte;

        public int NumberOfLatePaymentsInLastYear
        {
            get { return _timesLAte; }
            set { _timesLAte = value; }
        }
	

    }

}
