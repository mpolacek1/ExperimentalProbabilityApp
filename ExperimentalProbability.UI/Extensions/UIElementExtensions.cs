using System.Text;
using System.Windows;

namespace ExperimentalProbability.UI.Extensions
{
    public static class UIElementExtensions
    {
        public static void ChangeVisibility(this UIElement element, Visibility visibility)
        {
            element.Visibility = visibility;
        }
    }
}
