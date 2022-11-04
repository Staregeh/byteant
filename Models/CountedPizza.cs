namespace byteant.Models
{
    public class CountedPizza
    {
        public string name { get; set; }
        public int timesOrdered { get; set; }
        public List<string> toppings { get; set; }
        public CountedPizza(Pizza pizza, int times)
        {
            name = "";
            toppings = pizza.Toppings;
            foreach (var item in pizza.Toppings)
            {
                for (int i = 0; i < 2; i++)
                {
                    name += item[i];
                }
            }
            timesOrdered = times;
        }
    }
}
