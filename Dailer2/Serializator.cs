using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Dailer2
{
    internal class Serializator
    {
        
        public static T Read<T>(string filename)
        {
            string json = File.ReadAllText(filename);
            T types = JsonConvert.DeserializeObject<T>(json);
            return types;
        }

        public static void Write<T>(T types, string filename)
        {
            string json = JsonConvert.SerializeObject(types);
            File.WriteAllText(filename, json);
        }
    }
}
