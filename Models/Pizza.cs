namespace byteant.Models
{
    public class Pizza
    {
        public List<string> Toppings { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as Pizza;

            if (Toppings.SequenceEqual(other.Toppings))
                return true;

            return false;
        }
        //public override int GetHashCode()
        //{
        //    return Toppings.GetHashCode();
        //}
        public static bool operator ==(Pizza x, Pizza y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Pizza x, Pizza y)
        {
            return !(x == y);
        }
    }
}
