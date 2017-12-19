using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LearningKit.Data
{
    public class Data
    {
        [JsonProperty]
        public string Condition { get; set; }

        [JsonProperty]
        public string Solution { get; set; }

        [JsonProperty]
        public string Answer { get; set; }
    }

    public class DataStorage
    {
        public List<Data> Datas { get; private set; } = new List<Data>();

        public void Save() {
            var str = JsonConvert.SerializeObject(Datas);

            File.WriteAllText(Environment.CurrentDirectory + @"\data.json", str);
        }

        public void Load() {
            var fileName = Environment.CurrentDirectory + @"\data.json";

            if (File.Exists(fileName)) {
                Datas = JsonConvert.DeserializeObject<List<Data>>(File.ReadAllText(fileName));
            }
        }
    }
}
