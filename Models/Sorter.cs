namespace byteant.Models
{
    //Firstly, I had searched on Internet how to sort this, and found this https://www.geeksforgeeks.org/find-k-numbers-occurrences-given-array/
    //I was trying to use algorithm from this site, but I have run into a lot of problems
    //I have tried to do that sorting using Dictionary<Pizza, int> to assosiate pizzas with ordered times, but method ContainsKey always returned false.
    //That's why there are overrided methods in Pizza.
    //I think, compiler couldn't compare 2 pizzas, and I overrided that methods, and comparing 2 pizzas worked, but ContainsKey method still always returned false
    //I also tried to override method GetHashCode(), but that didn't solve my problem
    //So, I found my own solution, but I think it is too complex and resourceful. So, if you can tell what did i do wrong, or provide another better solution, it will be great
    public class Sorter
    {
        public static List<CountedPizza> find(IList<Pizza> pizzas)
        {
            List<int> counts = new List<int>();
            List<Pizza> counted = new List<Pizza>();
            for (int i = 0; i < pizzas.Count; i++)
            {
                if (counted.Contains(pizzas[i]))
                {
                    for (int k = 0; k < counted.Count; k++)
                    {
                        if (counted[k] == pizzas[i])
                        {
                            counts[k]++;
                        }
                    }
                }
                else
                {
                    counted.Add(pizzas[i]);
                    counts.Add(1);
                }
            }
            List<CountedPizza> countedPizzas = new List<CountedPizza>();
            for (var i = 0; i < counted.Count; i++)
            {
                countedPizzas.Add(new CountedPizza(counted[i], counts[i]));
            }
            IOrderedEnumerable<CountedPizza> orderedPizzas = countedPizzas.OrderByDescending(countedPizza => countedPizza.timesOrdered);
            List<CountedPizza> filteredPizzas = new List<CountedPizza>();
            for (int i = 0; i < 10; i++)
            {
                filteredPizzas.Add(orderedPizzas.ElementAt(i));
            }
            return filteredPizzas;
        }
    }
}
