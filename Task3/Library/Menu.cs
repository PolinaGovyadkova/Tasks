using Dishes;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Menu
    {
        public List<Dish> Dishes { get; set; }

        public Menu() => Dishes = new List<Dish>();

        public override bool Equals(object obj) => obj is Menu menu && menu.Dishes == Dishes;

        public override int GetHashCode()
        {
            var hash = Dishes.Sum(dshes => dshes.GetHashCode());
            return unchecked(hash);
        }

        public override string ToString() => $"Menu with dish id {Dishes}";
    }
}