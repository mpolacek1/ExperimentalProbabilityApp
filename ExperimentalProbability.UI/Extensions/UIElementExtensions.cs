using System.Windows;

namespace ExperimentalProbability.UI.Extensions
{
    public static class UIElementExtensions
    {
        public static void HideOrShow(this UIElement element, object determinationValue)
        {
            if (determinationValue == null)
            {
                element.Visibility = Visibility.Visible;
            }
            else
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
    }
}
