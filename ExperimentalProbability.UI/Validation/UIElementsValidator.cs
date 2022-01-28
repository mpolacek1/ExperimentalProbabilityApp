using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Validation
{
    public static class UIElementsValidator
    {
        public static bool Validate(this IntegerUpDown element)
        {
            return element.Value.HasValue;
        }
    }
}
