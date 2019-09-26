using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server_App.Services
{
    public class WCFClient
    {
        private static WCFClient instance;

        private WCFClient()
        {
        }

        public static WCFClient GetInstance()
        {
            if (instance == null)
            {
                if (instance == null)
                {
                    instance = new WCFClient();
                }
            }

            return instance;
        }

        public T GetConnection<T>(string serviceName)
        {
            ChannelFactory<T> factory = new ChannelFactory<T>(serviceName);
            return factory.CreateChannel();
        }
    }
}
