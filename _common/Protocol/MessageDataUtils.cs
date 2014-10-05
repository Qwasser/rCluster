using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


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

        public static ClusterMessage PackListMessage(List<string> data, MessageType type)
        {
            var sb = new StringBuilder();
            foreach (string item in data)
            {
                sb.Append(item);
                sb.Append(';');
            }
            return PackStringMessage(sb.ToString(), type);
        }

        public static void GetStringAndBool(string data, out string str, out bool predicate)
        {
            if (data.IndexOf(';') > 0 && data.IndexOf(';') < data.Length - 1)
            {
                str = data.Substring(0, data.IndexOf(';'));
                Boolean.TryParse(data.Substring(data.IndexOf(';') + 1), out predicate);
            }
            else
            {
                str = String.Empty;
                predicate = false;
            }
        }

        public static ClusterMessage PackStringAndBool(string str, bool b, MessageType type)
        {
            string res = str + ';' + b.ToString();
            return PackStringMessage(res, type);
        }

        public static ClusterMessage PackStringMessage(string msg, MessageType type)
        {
            var m = new ClusterMessage
            {
                Data = msg,
                Type = type
            };
            return m;
        }

        public static ClusterMessage PackIntMessage(int msg, MessageType type)
        {
            var m = PackStringMessage(msg.ToString(CultureInfo.InvariantCulture), type);
            return m;
        }
    }
}
