namespace ExperimentalProbability.Contracts.Models
{
    public class CalculationResultData
    {
        public CalculationResultData()
        {
            SimulationsRan = default;
            ConditionMet = default;
            Result = default;
        }

        public int SimulationsRan { get; set; }

        public int ConditionMet { get; set; }

        public decimal Result { get; set; }
    }
}
