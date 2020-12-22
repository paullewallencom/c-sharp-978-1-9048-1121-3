using System;
using System.Workflow.Activities;
using System.Threading;

namespace chapter3
{
    [ExternalDataExchange]
    interface IBugFlowService
    {
        void AssignBug(Bug bug);
        event EventHandler<BugAddedArgs> BugAdded;
    }

    public class BugFlowService : IBugFlowService
    {
        public void AssignBug(Bug bug)
        {
            // notify someone that it is time to assign a bug...
            Console.WriteLine("Assign '{0}' to a developer", bug.Title);
        }

        public void CreateBug(Guid instanceID, Bug bug)
        {
            // tell the workflow about the new bug 
            BugAddedArgs args = new BugAddedArgs(instanceID, bug);            
            //args.WaitForIdle = true;
            EventHandler<BugAddedArgs> ev = BugAdded;
            if (ev != null)
                ev(null, args);
        }
        
        public event EventHandler<BugAddedArgs> BugAdded;
    }

    [Serializable]
    public class Bug
    {
        public Bug(int id, string title, string description)
        {
            _id = id;
            _title = title;
            _description = description;
        }

        public Bug()
        {

        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }	
    }

    [Serializable]
    public class BugAddedArgs : ExternalDataEventArgs
    {
        public BugAddedArgs(Guid instanceId, Bug newBug)
            : base(instanceId)
        {
            _bug = newBug;
        }

        private Bug _bug;
        public Bug NewBug
        {
            get { return _bug; }
            set { _bug = value; }
        }	
    }    
}
