using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOfHeroesCore.Event.PaperEvent
{
    public class PaperPublishedEvent : Event<  PaperEventArgs>
    {
        public PaperPublishedEvent(PaperEventArgs obj) : base(obj)
        {
        }
    }
}
