namespace ExperimentalProbability.Calculation.Models
{
    public class BasicData
    {
        public BasicData(int numberOf, object items)
        {
            NumberOf = numberOf;
            Items = items;
        }

        public int NumberOf { get; set; }

        public object Items { get; set; }
    }
}
