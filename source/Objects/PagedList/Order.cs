namespace DotNetCore.Objects
{
    public class Order
    {
        public Order()
        {
            Ascending = true;
        }

        public Order(string property, bool ascending)
        {
            Property = property;
            Ascending = ascending;
        }

        public bool Ascending { get; set; }

        public string Property { get; set; }
    }
}
