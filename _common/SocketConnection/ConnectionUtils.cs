using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using _common.Protocol.Request;

namespace _common.SocketConnection
{
    class ConnectionUtils
    {
        public static readonly BinaryFormatter Formatter = new BinaryFormatter();


        public static T TryDecode<T>(string bytes)
        {
            byte[] b = Convert.FromBase64String(bytes);
            using (var stream = new MemoryStream(b))
            {
                stream.Seek(0, SeekOrigin.Begin);
                return (T)Formatter.Deserialize(stream);
            }
        }

        public static string Encode<T>(T msg)
        {
            using (var ms = new MemoryStream())
            {
                Console.Out.WriteLine("encoding");
                Formatter.Serialize(ms, msg);
                ms.Flush();
                ms.Position = 0;
                string res = Convert.ToBase64String(ms.ToArray());
                Console.Out.WriteLine(res);
                return res;
            }
        }
    }
}
