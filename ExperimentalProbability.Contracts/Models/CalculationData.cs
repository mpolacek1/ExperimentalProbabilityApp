namespace ExperimentalProbability.Contracts.Models
{
    public class CalculationData
    {
        public CalculationData(int simulationsToRun)
        {
            SimulationsToRun = simulationsToRun;
        }

        public int SimulationsToRun { get; set; }
    }
}