using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.UI.CustomElements.Panels;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Extensions
{
    public static class PanelExtensions
    {
        public static void ChangeVisibilityOfChild(this Panel element, int index, Visibility visibility)
        {
            element.Children[index].Visibility = visibility;
        }

        public static void RemoveNotNeededChildren(this Panel element, IntegerUpDown counter)
        {
            element.Children.RemoveRange(counter.GetValue(), counter.Maximum.Value - counter.GetValue());
        }
    }
}
