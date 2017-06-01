using System;
using System.IO;
using System.Net;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            ServiceListener sl = new ServiceListener();
            sl.StartAsyncListener();
        }

        protected override void OnStop()
        {
        }

        public void ShtTester()
        {
            var selfLocation = AppDomain.CurrentDomain.BaseDirectory;
            var someLocation = Directory.GetDirectories(@"c:\Program Files\", @"*a*");
        }
    }
}
