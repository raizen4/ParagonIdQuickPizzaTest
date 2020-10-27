namespace ParagonIdTest.Models
{
    public class Topping
    {
        public Topping(string id, string topingName)
        {
            Id = id;
            Name = topingName;
        }

        public Topping(){}
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
