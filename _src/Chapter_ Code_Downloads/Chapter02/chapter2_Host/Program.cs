using System;
using System.Workflow.Runtime;
using System.Threading;
using System.Workflow.ComponentModel.Compiler;
using System.CodeDom.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.IO;
using System.Xml;
using System.Reflection;
using ReSerialize;

namespace chapter2_Host
{
   static class Program
   {
      static void Main()
      {
         //ExecutePureXomlExample3();
         //CompilePureXomlExample3();
         ActivatePureXoml();
         //ExecutePureCode();         
         
         //SerializeCodeInstance();
         //SerializeXomlInstace();
         //SerializeCompiledInstance();
         //ReserializeCompiledType();

      }

      private static void ReserializeCompiledType()
      {         
         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (StringWriter stream = new StringWriter())
         using (XmlWriter writer = XmlWriter.Create(stream))
         {
            Type t = typeof(MyWorkflow);
            WorkflowInstance instance = runtime.CreateWorkflow(t);

            WorkflowMarkupSerializer serializer;
            serializer = new WorkflowMarkupSerializer();

            serializer.Serialize(
                  writer,
                  instance.GetWorkflowDefinition()
              );

            Console.WriteLine(stream.ToString());
         }
      }

      private static void SerializeCompiledInstance()
      {
         WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();

         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (StringWriter buffer = new StringWriter())
         using (XmlWriter writer = XmlWriter.Create(buffer))
         {

            WorkflowCompiler compiler = new WorkflowCompiler();
            WorkflowCompilerParameters parameters;
            parameters = new WorkflowCompilerParameters();
            parameters.GenerateInMemory = false;
            parameters.OutputAssembly = "testforserialization.dll";
            parameters.ReferencedAssemblies.Add("chapter2_Host.exe");
            string[] xomlFiles = { @"..\..\purexaml\purexaml3.xoml" };
            WorkflowCompilerResults compilerResults;
            compilerResults = compiler.Compile(parameters, xomlFiles);

            Type workflowType;
            workflowType = compilerResults.CompiledAssembly.GetType("MyWorkflow");
            WorkflowInstance instance = runtime.CreateWorkflow(workflowType);

            serializer.Serialize(writer, instance.GetWorkflowDefinition());
            Console.WriteLine(buffer.ToString());
         }        
         
      }

      private static void SerializeCodeInstance()
      {
         string fileName = @"..\..\PureCode\BackToXaml.xoml";

         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (FileStream stream = File.OpenWrite(fileName))
         using (XmlWriter writer = XmlWriter.Create(stream))
         {
            Type t = typeof(PureCode.MyWorkflow);
            WorkflowInstance instance = runtime.CreateWorkflow(t);

            WorkflowMarkupSerializer serializer;
            serializer = new WorkflowMarkupSerializer();
            
            serializer.Serialize(
                  writer, 
                  instance.GetWorkflowDefinition()
              );            
         }        
      }

      private static void SerializeXomlInstace()
      {
         WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();

         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (StringWriter buffer = new StringWriter())
         using (XmlWriter writer = XmlWriter.Create(buffer))
         {
            TypeProvider typeProvider = new TypeProvider(runtime);
            typeProvider.AddAssembly(Assembly.GetExecutingAssembly());
            runtime.AddService(typeProvider);

            XmlReader reader = XmlReader.Create(@"..\..\purexaml\purexaml5.xoml");            
            WorkflowInstance instance = runtime.CreateWorkflow(reader);
            serializer.Serialize(writer, instance.GetWorkflowDefinition());
            Console.WriteLine(buffer.ToString());
         }
      }



      private static void ExecutePureCode()
      {
         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (AutoResetEvent waitHandle = new AutoResetEvent(false))
         {
            runtime.WorkflowCompleted += delegate { waitHandle.Set(); };
            runtime.WorkflowTerminated += delegate { waitHandle.Set(); };

            Type t = typeof(PureCode.MyWorkflow);
            WorkflowInstance instance = runtime.CreateWorkflow(t);
            instance = runtime.CreateWorkflow(t);
            instance.Start();

            waitHandle.WaitOne();
         }

      }

      private static void ActivatePureXoml()
      {
         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (AutoResetEvent waitHandle = new AutoResetEvent(false))
         {
            runtime.WorkflowCompleted += delegate { waitHandle.Set(); };
            runtime.WorkflowTerminated += delegate { waitHandle.Set(); };

            TypeProvider typeProvider = new TypeProvider(runtime);
            typeProvider.AddAssembly(Assembly.GetExecutingAssembly());
            runtime.AddService(typeProvider);

            XmlReader reader = XmlReader.Create(@"..\..\purexaml\purexaml5.xoml");
            WorkflowInstance instance = runtime.CreateWorkflow(reader);
            instance.Start();

            waitHandle.WaitOne();
         }
      }

      private static void ExecutePureXomlExample3()
      {
         using (WorkflowRuntime runtime = new WorkflowRuntime())
         using (AutoResetEvent waitHandle = new AutoResetEvent(false))
         {
            runtime.WorkflowCompleted += delegate { waitHandle.Set(); };
            runtime.WorkflowTerminated += delegate { waitHandle.Set(); };

            Type workflowType = Type.GetType("MyWorkflow, purexaml3");
            WorkflowInstance instance = runtime.CreateWorkflow(workflowType);
            instance.Start();

            waitHandle.WaitOne();
         }
      }

      private static void CompilePureXomlExample3()
      {
         WorkflowCompiler compiler = new WorkflowCompiler();

         WorkflowCompilerParameters parameters;
         parameters = new WorkflowCompilerParameters();
         parameters.GenerateInMemory = true;
         parameters.ReferencedAssemblies.Add("chapter2_Host.exe");

         string[] xomlFiles = { @"..\..\purexaml\purexaml3.xoml" };

         WorkflowCompilerResults compilerResults;
         compilerResults = compiler.Compile(parameters, xomlFiles);

         if (compilerResults.Errors.Count > 0)
         {
            foreach (CompilerError error in compilerResults.Errors)
            {
               Console.WriteLine(error.ErrorText);
            }
         }
         else
         {
            using (WorkflowRuntime runtime = new WorkflowRuntime())
            using (AutoResetEvent waitHandle = new AutoResetEvent(false))
            {

               runtime.WorkflowCompleted += delegate { waitHandle.Set(); };
               runtime.WorkflowTerminated += delegate { waitHandle.Set(); };

               Type workflowType;
               workflowType = compilerResults.CompiledAssembly.GetType("MyWorkflow");
               WorkflowInstance instance = runtime.CreateWorkflow(workflowType);

               instance.Start();

               waitHandle.WaitOne();
            }
         }
      }

   }
}

