using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOfHeroesCore.Model
{
    public class Hero : IObjectId<int>
    {
        public Id<int> Id { get; set; } = IdInt.Create(0);
        public string Name { get; set; } = string.Empty;
        public PowerType PowerType { get; set; } =new PowerType();
        public Strength Strength { get; set; } = new Strength();
        public Popularity Popularity { get; set; } = new Popularity();
        public Paper[] Papers { get; set; } = new Paper[0];
        public DateTimeOffset LastUpdate { get;set; }
    }
}
