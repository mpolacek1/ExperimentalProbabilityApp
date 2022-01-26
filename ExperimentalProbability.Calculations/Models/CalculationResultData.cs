namespace ExperimentalProbability.Calculations.Models
{
    public class CalculationResultData
    {
        public CalculationResultData(int simulationsRun, int conditionsMet, double probability)
        {
            SimulationsRun = simulationsRun;
            ConditionsMet = conditionsMet;
            Probability = probability;
        }

        public int SimulationsRun { get; set; }

        public int ConditionsMet { get; set; }

        public double Probability { get; set; }
    }
}