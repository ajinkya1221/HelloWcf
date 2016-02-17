using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HelloWcf;

namespace ConsoleWcf
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Service1));
            try
            {
                host.Open();
                foreach (var channelDispatcher in host.ChannelDispatchers)
                {
                    if (channelDispatcher.Listener != null) Console.WriteLine("server is listening on port " + channelDispatcher.Listener.Uri.Port);
                }
                Console.WriteLine("press any key to exit");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception exception)
            {
                host.Close();
            }
        }
    }
}
