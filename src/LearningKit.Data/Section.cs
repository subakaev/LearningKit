using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LearningKit.Data
{
    public class Section
    {
        public Guid Guid { get; }

        public string Name { get; set; }

        public List<Section> Children { get; }

        [JsonIgnore]
        public Section Parent { get; set; }

        public Section() {
            Guid = Guid.NewGuid();
            Children = new List<Section>();
        }

        public Section(string name) : this() {
            Name = name;
        }

        public void AddChild(string name) {
            Children.Add(new Section(name) { Parent = this });
        }

        public void UpdateParent(Section parent) {
            Parent = parent;
            Children.ForEach(x => x.UpdateParent(this));
        }
    }
}
