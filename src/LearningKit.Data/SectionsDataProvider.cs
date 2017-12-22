using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LearningKit.Data
{
    public interface ISectionsStorage
    {
        IList<Section> Sections { get; }

        void Load();

        void Save();
    }

    public class JsonSectionsStorage : ISectionsStorage
    {
        private readonly string dataFilePath = LocationHelper.ResolveDataFilePath("sections.json");

        public IList<Section> Sections { get; private set; }

        public JsonSectionsStorage() {
            Sections = new List<Section>();

            Sections.Add(new Section("test"));
        }

        public void Load() {
            if (!File.Exists(dataFilePath))
                return;

            Sections = JsonConvert.DeserializeObject<Section[]>(File.ReadAllText(dataFilePath)).ToList();
        }

        public void Save() {
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(Sections));
        }
    }
}
