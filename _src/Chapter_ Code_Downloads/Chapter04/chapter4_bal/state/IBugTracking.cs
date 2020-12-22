using System;
using System.Workflow.Activities;

namespace chapter4_bal.state
{
    [ExternalDataExchange]
    interface IBugTracking
	{
        event EventHandler<BugArgs> BugAssigned;
        event EventHandler<BugArgs> BugClosed;
        event EventHandler<BugArgs> BugDeferred;
	}

    [Serializable]
    public class BugArgs : ExternalDataEventArgs
    {
        public BugArgs(Guid id) : base(id)
        {

        }
    }
}
