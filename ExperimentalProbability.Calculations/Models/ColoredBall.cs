namespace ExperimentalProbability.Calculations.Models
{
    public class ColoredBall
    {
        public ColoredBall(string color, int index)
        {
            Color = color;
            Index = index;
        }

        public string Color { get; set; }

        public int Index { get; set; }
    }
}
