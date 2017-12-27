using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LearningKit.Data
{
    public interface ISectionsStorage
    {
        IList<Section> Sections { get; }

        void AddSection(Section parent, string name);

        void RemoveSection(Guid guid);

        void Load();

        void Save();
    }

    public class JsonSectionsStorage : ISectionsStorage
    {
        private readonly string dataFilePath = LocationHelper.ResolveDataFilePath("sections.json");

        private List<Section> sections = new List<Section>();

        public IList<Section> Sections => new ReadOnlyCollection<Section>(sections);

        public void AddSection(Section parent, string name) {
            if (parent == null)
                sections.Add(new Section(name));
            else 
                parent.Children.Add(new Section(name));

            Save();
        }

        public void RemoveSection(Guid guid) {
            var section = sections.Single(x => x.Guid.Equals(guid));

            sections.Remove(section);

            Save();
        }

        public void Load() {
            if (!File.Exists(dataFilePath))
                return;

            sections = JsonConvert.DeserializeObject<Section[]>(File.ReadAllText(dataFilePath)).ToList();

            foreach (var section in sections) {
                section.UpdateParent(null);
            }
        }


        public void Save() {
            File.WriteAllText(dataFilePath, JsonConvert.SerializeObject(sections));
        }
    }
}
