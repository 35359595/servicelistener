using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace runner
{
    class ServiceListener
    {
        private bool _stahp = false;
        private static string _url = @"http://*/";
        public void StartAsyncListener()
        {
            new Thread(() =>
            {
                HttpListener _listener = new HttpListener();
                _listener.Prefixes.Add(_url);
                _listener.Start();
                while (!_stahp && _listener.IsListening)
                {
                    HttpListenerContext incContext = _listener.GetContext();
                    HttpListenerRequest incRequest = incContext.Request;
                    HttpListenerResponse outResponce = incContext.Response;
                    string responseString = "<HTML><BODY>Hello world!</BODY></HTML>";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    outResponce.ContentLength64 = buffer.Length;
                    System.IO.Stream output = outResponce.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                };
                _listener.Close();
            }).Start();
        }


        public async void StopAsyncListener()
        {
            HttpClient client = new HttpClient();
            _stahp = true;
            await client.GetStringAsync(_url.Replace("*", "localhost"));
        }
    }
}
