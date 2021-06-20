using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winform_task_2
{
    class Json
    {
       public static void JsonDeserializer()
        {
            Human[] humans = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("humans.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    humans = serializer.Deserialize<Human[]>(jr);
                }
                foreach (var item in humans)
                {
                    Console.WriteLine(item);
                }
            }
        }
        public static void JsonSerialize(List<Human> humans)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("humans.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, humans);
                }
            }
        }
    }
}
