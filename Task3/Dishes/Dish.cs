using Dishes.Interfaces;

namespace Dishes
{
    public class Dish : IDish
    {
        public Dish(Recipe recipe, string name)
        {
            Name = name;
            Recipe = recipe;
        }

        public Recipe Recipe { get; set; }
        public float Price => Recipe.Price;
        public float Weight { get; set; }
        public float Size { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj) => obj is Dish dish && dish.Recipe == Recipe && dish.Price == Price && dish.Weight == Weight && dish.Size == Size && dish.Name == Name;

        public override int GetHashCode()
        {
            return unchecked(Recipe.GetHashCode() + Price.GetHashCode() + Weight.GetHashCode() + Size.GetHashCode() + Name.GetHashCode());
        }

        public override string ToString()
        {
            return $"Dish  {Name} with {Price}";
        }
    }
}