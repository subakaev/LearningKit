using System;
using System.Collections.Generic;

namespace LearningKit.Data
{
    public class Section
    {
        public Guid Guid { get; }

        public string Name { get; set; }

        public List<Section> Children { get; }

        public Section() {
            Guid = Guid.NewGuid();
            Children = new List<Section>();
        }

        public Section(string name) : this() {
            Name = name;
        }
    }
}
