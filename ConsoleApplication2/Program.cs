using System; 
using System.Web; 
using System.Web.Hosting; 
using System.Net; 
using System.IO; 

class Program { 
    static void Main(string[] args) { 
        MySimpleHost msh = (MySimpleHost) ApplicationHost.CreateApplicationHost( typeof(MySimpleHost), "/", Directory.GetCurrentDirectory()); HttpListener listener = new HttpListener(); listener.Prefixes.Add("http://localhost:8081/"); listener.Prefixes.Add("http://127.0.0.1:8081/"); listener.Start(); Console.WriteLine( "Listening for requests on http://localhost:8081/"); while (true) { HttpListenerContext ctx = listener.GetContext(); string page = ctx.Request.Url.LocalPath.Replace("/", ""); string query = ctx.Request.Url.Query.Replace("?", ""); Console.WriteLine("Received request for {0}?{1}", page, query); StreamWriter sw = new StreamWriter(ctx.Response.OutputStream); msh.ProcessRequest(page, query, sw); sw.Flush(); ctx.Response.Close(); } } } public class MySimpleHost : MarshalByRefObject { public void ProcessRequest(string p, string q, TextWriter tw) { SimpleWorkerRequest swr = new SimpleWorkerRequest(p, q, tw); HttpRuntime.ProcessRequest(swr); } }
