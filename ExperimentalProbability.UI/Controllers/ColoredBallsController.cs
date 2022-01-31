using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.Calculations.Types;
using ExperimentalProbability.UI.Properties;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Controllers
{
    public static class ColoredBallsController
    {
        public static void UpdateControlsToColoredBalls(this MainWindow window)
        {
            window.UpdateControlsBasedOnCurrentType(
                Resources.Text_Pool_Size_ColoredBalls,
                (Style)Application.Current.Resources["IntegerUpDownColoredBallsPoolSize"],
                Resources.Text_Condition_ColoredBalls_NumberOfTakenItems,
                Resources.Default_Condition_ColoredBalls_NumberOfTakenItems);
        }

        public static void UpdateColoredBallsControls(this MainWindow window, Visibility visibility)
        {
            window.Text_ColoredBalls_NumberOfColors.Visibility = visibility;
            window.ColoredBalls_NumberOfColors.Visibility = visibility;
            window.Panel_ColoredBalls_Selection_Color.Visibility = visibility;

            window.Text_ColoredBalls_NumberOfColors.Text = Resources.Text_ColoredBalls_NumberOfColors;
            window.ColoredBalls_NumberOfColors.Text = Resources.Default_ColoredBalls_NumberOfColors;
        }

        public static void UpdateColorSelectionItemsSources(this MainWindow window)
        {
            var colorPanels = window.Panel_ColoredBalls_Selection_Color.Children;

            for (int i = 0; i < colorPanels.Count; i++)
            {
                var allColors = window.Colors;
                var selector = (ComboBox)((Panel)colorPanels[i]).Children[0];

                selector.ItemsSource = UpdateSelectorItemsSource(
                    selector.SelectedItem,
                    colorPanels.GetCurrentSelectedItemsFromPanels(window.ColoredBalls_NumberOfColors.Value.Value),
                    allColors.ToList());
            }
        }

        public static void RunColoredBallsCalculationAndDisplayResult(this MainWindow window)
        {
            var resultData = new Pool_ColoredBalls(GetCalculationData(window)).Calculate();
            return;
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

        private static CalculationData GetCalculationData(MainWindow window)
        {
            return new CalculationData(GetTypeSettings(window), GetConditionSettings(window), window.Simulations.Value.Value);
        }

        private static TypeSettings GetTypeSettings(MainWindow window)
        {
            return new TypeSettings(
                window.Pool_Size.Value.Value,
                GetPool(window));
        }

        private static Dictionary<string, int> GetPool(MainWindow window)
        {
            var numberOfColors = window.ColoredBalls_NumberOfColors.Value.Value;
            var pool = new Dictionary<string, int>(numberOfColors);

            var colorPanels = window.Panel_ColoredBalls_Selection_Color.Children;
            var selectedColors = colorPanels.GetCurrentSelectedItemsFromPanels(numberOfColors);
            var numberOfEachColor = GetNumberOfEachColor(colorPanels);

            for (int i = 0; i < numberOfColors; i++)
            {
                pool.Add(selectedColors[i], numberOfEachColor[i]);
            }

            return pool;
        }

        private static List<int> GetNumberOfEachColor(UIElementCollection colorPanels)
        {
            var numberOfEachColor = new List<int>(colorPanels.Count);

            for (int i = 0; i < colorPanels.Count; i++)
            {
                numberOfEachColor.Add(((IntegerUpDown)((Panel)colorPanels[i]).Children[2]).Value.Value);
            }

            return numberOfEachColor;
        }

        private static List<string> GetConditionSettings(MainWindow window)
        {
            return window.Panel_Condition_Selection_Outcome.Children.GetCurrentSelectedItemsFromPanels(window.Condition_NumberOfTakenItems.Value.Value);
        }
    }
}
