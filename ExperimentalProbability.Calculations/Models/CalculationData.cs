namespace ExperimentalProbability.Calculations.Models
{
    public class CalculationData
    {
        public int Type { get; set; }

        public int Condition { get; set; }

        public int Simulations { get; set; }

        public CalculationData(int type, int condition, int simulations)
        {
            Type = type;
            Condition = condition;
            Simulations = simulations;
        }
    }
}