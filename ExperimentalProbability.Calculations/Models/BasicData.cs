namespace ExperimentalProbability.Calculation.Models
{
    public class BasicData
    {
        public BasicData(object numberOf, object items)
        {
            NumberOf = numberOf;
            Items = items;
        }

        public object NumberOf { get; set; }

        public object Items { get; set; }
    }
}
