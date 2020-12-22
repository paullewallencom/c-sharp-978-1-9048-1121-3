using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Workflow.Runtime.Tracking;
using System.Workflow.Runtime.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Data;

namespace chapter6_runtime.tracking
{
	public class Tracking
	{
    static public void RunSimple()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowWithTracking"))      
      using (AutoResetEvent reset = new AutoResetEvent(false))
      {
        runtime.WorkflowCompleted += delegate { reset.Set(); };
        runtime.WorkflowTerminated += delegate { reset.Set(); };

        WorkflowInstance instance;
        instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
        instance.Start();
        reset.WaitOne();

        DumpTrackingEvents(instance.InstanceId);
      }
    }

    public static void DumpTrackingEvents(Guid instanceID)
    {      
      WorkflowRuntimeSection config;
      config = ConfigurationManager.GetSection("WorkflowWithTracking") 
               as WorkflowRuntimeSection;
      
      SqlTrackingQuery query = new SqlTrackingQuery();
      query.ConnectionString = 
        config.CommonParameters["ConnectionString"].Value;

      SqlTrackingWorkflowInstance trackingInstace;
      query.TryGetWorkflow(instanceID, out trackingInstace);
      if (trackingInstace != null)
      {
        Console.WriteLine("Tracking Information for {0}", instanceID);

        Console.WriteLine("  Workflow Events");
        foreach(WorkflowTrackingRecord r in trackingInstace.WorkflowEvents)
        {
                      
          Console.WriteLine("    Date: {0}, Status: {1}", 
                            r.EventDateTime, r.TrackingWorkflowEvent);
        }
        
        Console.WriteLine("  Activity Events");
        foreach (ActivityTrackingRecord r in trackingInstace.ActivityEvents)
        {
          Console.WriteLine("    Activity: {0} Date: {1} Status: {2}",
            r.QualifiedName, r.EventDateTime, r.ExecutionStatus);

        }      
      }
    }

    static public void RunWithTrackingProfile()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowWithTracking"))
      using (AutoResetEvent reset = new AutoResetEvent(false))
      {
        runtime.WorkflowCompleted += delegate { reset.Set(); };
        runtime.WorkflowTerminated += delegate { reset.Set(); };

        WorkflowInstance instance;
        instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
        instance.Start();
        reset.WaitOne();

        DumpTrackingEvents(instance.InstanceId);
      }
    }
	}

  public class CustomTracking
  {
    static public void Run()
    {
      using (WorkflowRuntime runtime =
        new WorkflowRuntime("WorkflowWithTracking"))
      using (AutoResetEvent reset = new AutoResetEvent(false))
      {
        runtime.WorkflowCompleted += delegate { reset.Set(); };
        runtime.WorkflowTerminated += delegate { reset.Set(); };

        CreateCustomTrackingProfile();

        WorkflowInstance instance;
        instance = runtime.CreateWorkflow(typeof(SimpleWorkflow));
        instance.Start();
        reset.WaitOne();

        Tracking.DumpTrackingEvents(instance.InstanceId);
      }
    }

    private static void CreateCustomTrackingProfile()
    {
      TrackingProfile profile = new TrackingProfile();
      profile.Version = new Version("1.0.0");           

      WorkflowTrackPoint workflowTrackPoint = new WorkflowTrackPoint();
            
      Array statuses = Enum.GetValues(typeof(TrackingWorkflowEvent));     
      foreach (TrackingWorkflowEvent status in statuses)
      {
        workflowTrackPoint.MatchingLocation.Events.Add(status);
      }
      profile.WorkflowTrackPoints.Add(workflowTrackPoint);

      string profileAsXml = SerializeProfile(profile);
      UpdateTrackingProfile(profileAsXml);
    }

    private static string SerializeProfile(TrackingProfile profile)
    {
      TrackingProfileSerializer serializer;
      serializer = new TrackingProfileSerializer();

      StringWriter writer = new StringWriter(new StringBuilder());
      serializer.Serialize(writer, profile);

      return writer.ToString();
    }

    private static void UpdateTrackingProfile(string profileAsXml)
    {
      WorkflowRuntimeSection config;
      config = ConfigurationManager.GetSection("WorkflowWithTracking")
                as WorkflowRuntimeSection;

      using (SqlConnection connection = new SqlConnection())
      {
        connection.ConnectionString = 
          config.CommonParameters["ConnectionString"].Value;        

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "dbo.UpdateTrackingProfile";

        command.Parameters.Add(
          new SqlParameter("@TypeFullName", 
                typeof(SimpleWorkflow).ToString()));
        
        command.Parameters.Add(
          new SqlParameter("@AssemblyFullName",
                typeof(SimpleWorkflow).Assembly.FullName));
        
        command.Parameters.Add(
          new SqlParameter("@Version","1.0.0"));
        
        command.Parameters.Add(
          new SqlParameter("@TrackingProfileXml", profileAsXml));

        connection.Open();
        command.ExecuteNonQuery();

      }
    }
  }
}
