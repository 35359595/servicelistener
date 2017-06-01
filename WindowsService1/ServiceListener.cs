using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    class ServiceListener
    {
        private HttpListener _listener;
        public ServiceListener()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(@"http://*/boo/");
        }
        private async Task MyListener()
        {
            HttpListenerContext incContext = _listener.GetContext();
            HttpListenerRequest incRequest = incContext.Request;
            HttpListenerResponse outResponce = incContext.Response;
            string responseString = "<HTML><BODY> Hello world!</BODY></HTML>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            outResponce.ContentLength64 = buffer.Length;
            System.IO.Stream output = outResponce.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            await MyListener();
        }

        public async void StartAsyncListener()
        {
            _listener.Start();
            await MyListener();
        }
    }
}
