using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningKit.Data;
using Prism.Events;

namespace LearningKit.Gui.Events
{
    public class SectionChangedEvent : PubSubEvent<Section>
    {
    }
}
