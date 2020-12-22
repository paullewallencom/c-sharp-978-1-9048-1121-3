using System;
using System.Collections.Generic;
using System.Text;
using Otc.Workflow.Services;
using System.Threading;

namespace BugTrackingServices
{
    public class BugFlowService : IBugService
    {


        public bool RequestUpload(Guid id, string userName)
        {
            UploadCompletedEventArgs ea = new UploadCompletedEventArgs(id, "foo.doc");
            ea.WaitForIdle = true;            
            EventHandler<UploadCompletedEventArgs> eh = UploadCompleted;
            if (eh != null)
            {
                ThreadPool.QueueUserWorkItem(
                    delegate { eh(null, ea); }
                    );                
            }
            return true;
        }

        public event EventHandler<UploadCompletedEventArgs> UploadCompleted;


    }
}
