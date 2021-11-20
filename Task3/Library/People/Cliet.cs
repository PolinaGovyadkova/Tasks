using System.Collections.Generic;

namespace Library.People
{
    public class Client
    {
        public List<int> DishName;

        public Client(int id) => DishName = new List<int> { id };

        public int Id { get; set; }

        public override bool Equals(object obj) => obj is Client client && client.DishName == DishName;

        public override int GetHashCode() => unchecked(DishName.GetHashCode());

        public override string ToString() => $"Client with menu item {DishName} ";
    }
}