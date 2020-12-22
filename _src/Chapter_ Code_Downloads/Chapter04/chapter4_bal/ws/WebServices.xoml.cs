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
using chapter4_bal.com.msn.search.soap;

namespace chapter4_bal.ws
{
	public partial class WebServices : SequentialWorkflowActivity
	{
        SearchRequest searchRequest = null;
        public SearchResponse invokeWebServiceActivity1__ReturnValue_1 = new chapter4_bal.com.msn.search.soap.SearchResponse();
        public SearchRequest invokeWebServiceActivity1_Request1 = new chapter4_bal.com.msn.search.soap.SearchRequest();
        public Guid webServiceInputActivity1_id1 = default(System.Guid);
        public string webServiceInputActivity1_userName1 = default(System.String);

        private void invokeWebServiceActivity1_Invoking(object sender, InvokeWebServiceEventArgs e)
        {
            searchRequest = new SearchRequest();
            searchRequest.Query = "foo";
        }

        private void invokeWebServiceActivity1_Invoked(object sender, InvokeWebServiceEventArgs e)
        {

        }
    }
}
