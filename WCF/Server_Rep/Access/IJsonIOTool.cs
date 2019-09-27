using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Rep.Access
{
    public interface IJsonIOTool<T>
    {
        List<T> ReadAll();
        void WriteAll(List<T> items);
    }
}
