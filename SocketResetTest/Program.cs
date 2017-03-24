using System;
using System.Net;

namespace SocketResetTest
{
	class Program
	{
        static void Main(string[] args)
        {
            Console.WriteLine("Starting SocketReset Test");
            var httpStatus = SubmitRequest("http://www.google.com");
            Console.WriteLine($"Received HTTP status: {httpStatus}");

            // just wait forever
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
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    return response.StatusCode;
                }
            }
        }
    }
}
