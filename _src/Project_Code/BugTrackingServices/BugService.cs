using System;
using System.Workflow.Activities;

namespace Otc.Workflow.Services
{
    [ExternalDataExchange]
    public interface IBugService
    {
        bool RequestUpload(Guid id, string userName);
        //void AssignBug(Bug bug);
        event EventHandler<UploadCompletedEventArgs> UploadCompleted;
        //event EventHandler<BugAddedArgs> BugAdded;        
    }

    [Serializable]
    public class UploadCompletedEventArgs : ExternalDataEventArgs
    {
        public UploadCompletedEventArgs(Guid id, string filename)
            : base(id)
        {
            _fileName = filename;
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
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
