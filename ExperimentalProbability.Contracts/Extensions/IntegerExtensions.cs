namespace ExperimentalProbability.Contracts.Extensions
{
    public static class IntegerExtensions
    {
        public static int Length(this int value)
        {
            return value.ToString().Length;
        }

        public static int GetMaxValueIfExceeded(this int value, int maxValue)
        {
            return value < maxValue ? value : maxValue;
        }
    }
}
