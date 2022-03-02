using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Extensions
{
    public static class IntegerUpDownExtensions
    {
        public static void SetValueToMin(this IntegerUpDown element)
        {
            element.Value = element.Minimum;
        }

        public static int GetValue(this IntegerUpDown element)
        {
            return element.Validate() ? element.Value.Value : 0;
        }

        public static bool Validate(this IntegerUpDown element)
        {
            return element.Value.HasValue;
        }
    }
}
