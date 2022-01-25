using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExperimentalProbability.UI.Properties;
using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.Calculations.Types;
using System.Windows.Controls;
using System.Windows;
using ExperimentalProbability.UI.CustomControls;

namespace ExperimentalProbability.UI.Controllers
{
    public static class ColoredBallsController
    {
        public static void UpdateControlsToColoredBalls(this MainWindow window)
        {
            window.UpdateControlsBasedOnCurrentType(
                Resources.Text_Pool_Size_ColoredBalls,
                Resources.Default_Pool_Size_ColoredBalls,
                Resources.Text_Condition_ColoredBalls_NumberOfTakenItems,
                Resources.Default_Condition_ColoredBalls_NumberOfTakenItems
            );
        }

        public static void UpdateColoredBallsControls(this MainWindow window, Visibility visibility)
        {
            window.Text_ColoredBalls_NumberOfColors.Visibility = visibility;
            window.ColoredBalls_NumberOfColors.Visibility = visibility;
            window.Panel_ColoredBalls_Selection_Color.Visibility = visibility;

            window.Text_ColoredBalls_NumberOfColors.Text = Resources.Text_ColoredBalls_NumberOfColors;
            window.ColoredBalls_NumberOfColors.Text = Resources.Default_ColoredBalls_NumberOfColors;
        }

        public static string[] GetColoredBallsSelectionItemsSource(this MainWindow window)
        {
            return GetCurrentSelectedColors(
                window.Panel_ColoredBalls_Selection_Color.Children,
                new List<string>(int.Parse(window.ColoredBalls_NumberOfColors.Text))
            ).ToArray();
        }

        public static void UpdateColorSelectionItemsSources(this MainWindow window)
        {
            var colorPanels = window.Panel_ColoredBalls_Selection_Color.Children;

            var selectedColors = GetCurrentSelectedColors(
                colorPanels,
                new List<string>(int.Parse(window.ColoredBalls_NumberOfColors.Text))
            );

            for (int i = 0; i < colorPanels.Count; i++)
            {
                var allColors = new string[window.Colors.Length];
                window.Colors.CopyTo(allColors, 0);

                var selector = (ComboBox)((Panel)colorPanels[i]).Children[0];

                selector.ItemsSource = UpdateSelectorItemsSource(selector.SelectedItem, selectedColors, allColors.ToList());
            }
        }

        private static List<string> GetCurrentSelectedColors(UIElementCollection itemPanels, List<string> selectedItems)
        {
            for (int i = 0; i < itemPanels.Count; i++)
            {
                var selectedItem = ((ComboBox)((Panel)itemPanels[i]).Children[0]).SelectedItem;

                if (selectedItem != null)
                {
                    selectedItems.Add(selectedItem.ToString());
                }
            }

            return selectedItems;
        }

        private static List<string> UpdateSelectorItemsSource(object selectedItem, List<string> selectedItems, List<string> itemsSource)
        {
            for (int i = 0; i < selectedItems.Count; i++)
            {
                if (selectedItem == null
                    || !selectedItem.Equals(selectedItems[i]))
                {
                    itemsSource.Remove(selectedItems[i]);
                }
            }

            return itemsSource;
        }
    }
}
