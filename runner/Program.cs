using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace runner
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ServiceListener>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(() => new ServiceListener());
                    serviceInstance.WhenStarted(constructor => constructor.StartAsyncListener());
                    serviceInstance.WhenStopped(constructor => constructor.StopAsyncListener());
                });
                serviceConfig.SetServiceName("tstest");
                serviceConfig.StartManually();
            });
        }
    }
}
