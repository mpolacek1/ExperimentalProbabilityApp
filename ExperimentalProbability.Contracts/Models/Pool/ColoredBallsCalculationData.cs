namespace ExperimentalProbability.Contracts.Models.Pool
{
    public class ColoredBallsCalculationData : CalculationData
    {
        public ColoredBallsCalculationData(int simulationsToRun, int ballCount, object[] poolColors, int[] colorCounts, object[] conditionColors, object[] bag)
            : base(simulationsToRun)
        {
            BallCount = ballCount;
            PoolColors = poolColors;
            ColorCounts = colorCounts;
            ConditionColors = conditionColors;
            Bag = bag;
        }

        public int BallCount { get; set; }

        public object[] PoolColors { get; set; }

        public int[] ColorCounts { get; set; }

        public object[] ConditionColors { get; set; }

        public object[] Bag { get; set; }
    }
}
