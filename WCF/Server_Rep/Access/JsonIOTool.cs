using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Rep.Access
{
    public class JsonIOTool<T> : IJsonIOTool<T>
    {
        private string path;

        public JsonIOTool(string path)
        {
            this.path = path;
        }

        public List<T> ReadAll()
        {
            string JSONstring = File.ReadAllText(path);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(JSONstring);
            return list;
        }

        public void WriteAll(List<T> items)
        {
            string JSONout = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(path, JSONout);
        }
    }
}
