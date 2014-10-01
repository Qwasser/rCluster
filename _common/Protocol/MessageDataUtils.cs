using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _common.Protocol
{
    class MessageDataUtils
    {
        public static int GetIntFromData(string data)
        {
            int res;
            Int32.TryParse(data, out res);
            return res;
        }

        public static List<string> GetSemicolonListFromData(string data)
        {
            List<string> result = data.Split(';').ToList();
            return result;
        }
    }
}
