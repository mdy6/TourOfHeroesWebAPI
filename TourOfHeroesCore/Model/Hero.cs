using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOfHeroesCore.Model
{
    internal class Hero : IObjectId<int>
    {
        public Id<int> Id { get; set; }
        public string Name { get; set; }
        public PowerType PowerType { get; set; }
        public Strength Strength { get; set; }
        public Like LikeCount { get;set; }

        public Paper[] Papers { get; set; }

    }
}
