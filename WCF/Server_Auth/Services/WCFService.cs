using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server_Auth.Services
{
    public class WCFService : IDisposable
    {
        private ServiceHost host;
        private string name;
        private Type serviceType;

        public WCFService(string name, Type serviceType)
        {
            this.name = name;
            this.serviceType = serviceType;
        }

        public void Create()
        {
            host = new ServiceHost(serviceType);
        }

        public void Open()
        {
            try
            {
                if (host == null || (host.State != CommunicationState.Opened && host.State != CommunicationState.Opening))
                {
                    if (host == null)
                        Create();
                    host.Open();
                    Console.WriteLine($"Service Host for {name} is opened!");
                }


            }
            catch (Exception)
            {

                Console.WriteLine($"Service Host for {name} failed to open!");
            }
        }

        public void Close()
        {
            try
            {
                if (host.State != CommunicationState.Closed && host.State != CommunicationState.Closing)
                {
                    host.Close();
                    host = null;
                    Console.WriteLine($"Service Host for {name} is closed!");
                }

            }
            catch (Exception)
            {

                Console.WriteLine($"Service Host for {name} failed to close!");
            }
        }

        public void Dispose()
        {
            Close();
            host = null;
        }
    }
}
