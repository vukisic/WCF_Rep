using Common;
using Common.Contracts;
using Common.Models;
using Server_Rep.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Rep.Services
{
    public class ReplicationService : IReplicationContract
    {
        private string fileName = "../../../data.json";
        private IJsonIOTool<AppUser> json;

        public ReplicationService()
        {
            json = new JsonIOTool<AppUser>(fileName);
        }
        public List<AppUser> GetData()
        {
            return json.ReadAll();
        }

        public void SendData(List<AppUser> users)
        {
            var list = json.ReadAll();
            foreach (var item in users)
            {
                if (!Contains(list, item))
                {
                    list.Add(item);
                }
            }

            json.WriteAll(list);
        }

        private bool Contains(List<AppUser> list,AppUser entity)
        {
            foreach (var item in list)
            {
                if (item.Username == entity.Username)
                    return true;
            }
            return false;
        }
    }
}
