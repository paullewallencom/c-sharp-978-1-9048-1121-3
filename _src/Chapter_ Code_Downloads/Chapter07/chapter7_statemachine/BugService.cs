using System;
using System.Workflow.Activities;

namespace chapter7_statemachine
{
    [ExternalDataExchange]
    public interface IBugService
    {
        event EventHandler<BugStateChangedEventArgs> BugOpened;
        event EventHandler<BugStateChangedEventArgs> BugResolved;
        event EventHandler<BugStateChangedEventArgs> BugClosed;
        event EventHandler<BugStateChangedEventArgs> BugDeferred;
        event EventHandler<BugStateChangedEventArgs> BugAssigned;
    }

    [Serializable]
    public class BugStateChangedEventArgs : ExternalDataEventArgs
    {
        public BugStateChangedEventArgs(Guid instanceID, Bug bug)
            : base(instanceID)
        {
            _bug = bug;
            WaitForIdle = true;
        }

        private Bug _bug;

        public Bug Bug
        {
            get { return _bug; }
            set { _bug = value; }
        }
	
    }

    [Serializable]
    public class Bug
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _assignedto;
        public string AssignedTo
        {
            get { return _assignedto; }
            set { _assignedto = value; }
        }	
    }

    public class BugService : IBugService
    {
        public event EventHandler<BugStateChangedEventArgs> BugOpened;
    
        public event EventHandler<BugStateChangedEventArgs> BugResolved;

        public event EventHandler<BugStateChangedEventArgs> BugClosed;

        public event EventHandler<BugStateChangedEventArgs> BugDeferred;

        public event EventHandler<BugStateChangedEventArgs> BugAssigned;

        public void OpenBug(Guid id, Bug bug)
        {
            if (BugOpened != null)
                BugOpened(null, new BugStateChangedEventArgs(id, bug));
        }
        
        public void ResolveBug(Guid id, Bug bug)
        {
            if (BugResolved != null)
                BugResolved(null, new BugStateChangedEventArgs(id, bug));
        }

        public void CloseBug(Guid id, Bug bug)
        {
            if(BugClosed != null)
                BugClosed(null, new BugStateChangedEventArgs(id, bug));
        }

        public void DeferBug(Guid id, Bug bug)
        {
            if (BugDeferred != null)
                BugDeferred(null, new BugStateChangedEventArgs(id, bug));
        }

        public void AssignBug(Guid id, Bug bug)
        {
            if (BugAssigned != null)
                BugAssigned(null, new BugStateChangedEventArgs(id, bug));
        }
    }
}
