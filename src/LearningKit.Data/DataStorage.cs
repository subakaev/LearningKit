using System;
using System.Collections.Generic;
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
        public string Answer { get; set; }
    }

    public class DataStorage
    {
        public List<Data> Datas { get; } = new List<Data> {new Data {Condition = "Test condition <h1>afdasf</h1>", Answer = "<h2>afd</h2>"}};

        public void Save() {
            var str = JsonConvert.SerializeObject(Datas);

            var obj = JsonConvert.DeserializeObject<Data[]>(str);
        }

        public void Load() {
        }
    }
}
