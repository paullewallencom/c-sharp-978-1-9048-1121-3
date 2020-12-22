using System;
using System.Workflow.Activities;
using System.Threading;

namespace chapter4_bal
{

    [ExternalDataExchange]
    interface IBugService
    {
        bool RequestUpload(Guid id, string userName);
        event EventHandler<UploadCompletedEventArgs> UploadCompleted;
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

    public class BugFlowService : IBugService
    {

        #region IBugService Members

        public bool RequestUpload(Guid id, string userName)
        {
            // let's pretend we can immediatly upload the document
            // and raise the event
            UploadCompletedEventArgs e = new UploadCompletedEventArgs(id, "foo.doc");
            //e.WaitForIdle = true;
            //ThreadPool.QueueUserWorkItem(
            //    delegate
            //    {
                    EventHandler<UploadCompletedEventArgs> evh = UploadCompleted;
                    if (evh != null)
                        evh(null, e);
            //    }
            //);

            return true;
        }

        public event EventHandler<UploadCompletedEventArgs> UploadCompleted;

        #endregion
    }
}