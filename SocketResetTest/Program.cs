using System;
using System.Net;
using System.Threading;
using ObjectPrinter;

namespace SocketResetTest
{
	class Program
	{
        static void Main(string[] args)
        {
            Console.WriteLine("Starting SocketReset Test");

            var url = (Environment.GetEnvironmentVariable("URL_TO_GET") ?? "http://www.google.com");
            var runTime = TimeSpan.FromSeconds(int.Parse(Environment.GetEnvironmentVariable("RUN_TIME_IN_SECONDS") ?? "30"));
            var stopTime = DateTime.Now.Add(runTime);

            while (DateTime.Now < stopTime)
            {
                var httpStatus = SubmitRequest(url);
                Console.WriteLine($"Received HTTP status {httpStatus} from {url}");
                Thread.Sleep(1000);
            }

            // just wait forever
            Console.WriteLine("Done running test, waiting for signal...");
            Console.ReadLine();
        }
		
		private static HttpStatusCode SubmitRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.DumpToString());
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    return response.StatusCode;
                }
            }
        }
    }
}
