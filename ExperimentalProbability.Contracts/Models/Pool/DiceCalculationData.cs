namespace ExperimentalProbability.Contracts.Models.Pool
{
    public class DiceCalculationData : CalculationData
    {
        public DiceCalculationData(int simulationsToRun, int sideCount, int[] conditionSides)
            : base(simulationsToRun)
        {
            SideCount = sideCount;
            ConditionSides = conditionSides;
        }

        public int SideCount { get; private set; }

        public int[] ConditionSides { get; private set; }
    }
}
