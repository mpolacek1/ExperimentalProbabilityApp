using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.UI.CustomUIElements;
using ExperimentalProbability.UI.Properties;

namespace ExperimentalProbability.UI.Controllers
{
    public static class MainWindowController
    {
        public static void UpdateControlsBasedOnCurrentType(this MainWindow window, string poolText, Style poolSizeStyle, string textNumberOfTakenItems, string defaultNumberOfTakenItems)
        {
            UpdateContent(window, poolText, poolSizeStyle, textNumberOfTakenItems, defaultNumberOfTakenItems);
            UpdateVisibility(window, Visibility.Visible);

            window.Button_Run.IsEnabled = true;
        }

        public static void GenerateItemsSelection(this MainWindow window, UIElementCollection itemPanelChildren, int numberOfItems, string text = null, List<string> itemsSource = null)
        {
            for (int i = itemPanelChildren.Count; i < numberOfItems; i++)
            {
                itemPanelChildren.Add(GetItemSelectionPanel(window, text, itemsSource));
            }
        }

        public static void UpdateOutcomeSelectorsItemsSource(this MainWindow window)
        {
            var selectedItems = window.Panel_ColoredBalls_Selection_Color.Children.GetCurrentSelectedItemsFromPanels(window.ColoredBalls_NumberOfColors.Value.Value);
            var itemSelectionPanels = window.Panel_Condition_Selection_Outcome.Children;

            for (int i = 0; i < itemSelectionPanels.Count; i++)
            {
                var selector = (ComboBox)((Panel)itemSelectionPanels[i]).Children[0];
                selector.ItemsSource = selectedItems;
            }
        }

        public static List<string> GetCurrentSelectedItemsFromPanels(this UIElementCollection itemPanels, int numberOfItems)
        {
            var selectedItems = new List<string>(numberOfItems);

            for (int i = 0; i < itemPanels.Count; i++)
            {
                object selectedItem = ((ComboBox)((Panel)itemPanels[i]).Children[0]).SelectedItem;

                if (selectedItem != null)
                {
                    selectedItems.Add(selectedItem.ToString());
                }
            }

            return selectedItems;
        }

        public static void ClearNotNeededItemPanels(this UIElementCollection itemPanels, int numberOfItems)
        {
            for (int i = itemPanels.Count - 1; i >= numberOfItems; i--)
            {
                itemPanels.RemoveAt(i);
            }
        }

        private static void UpdateContent(MainWindow window, string poolText, Style poolSizeStyle, string textNumberOfTakenItems, string defaultNumberOfTakenItems)
        {
            window.Text_Pool_Size.Text = poolText;
            window.Pool_Size.Style = poolSizeStyle;
            window.Text_Condition_NumberOfTakenItems.Text = textNumberOfTakenItems;
            window.Condition_NumberOfTakenItems.Text = defaultNumberOfTakenItems;
        }

        private static void UpdateVisibility(MainWindow window, Visibility visibility)
        {
            window.Panel_Settings_Type.Visibility = visibility;
            window.Panel_Settings_Condition.Visibility = visibility;
        }

        private static Panel GetItemSelectionPanel(MainWindow window, string text, List<string> itemsSource)
        {
            return itemsSource == null ? new ItemSelectionPanel(window) : new ItemSelectionPanel(text, itemsSource);
        }

        private static void DisplayResult(MainWindow window, CalculationResultData result)
        {
            BuildResultText(Resources.Text_SimulationsRun, result.SimulationsRun);
            BuildResultText(Resources.Text_ConditionsMet, result.ConditionsMet);
            BuildResultText(Resources.Text_Probability, result.Probability);
        }

        private static string BuildResultText(string text, IConvertible number)
        {
            var builder = new StringBuilder(text);
            builder.Append(' ');
            builder.Append(number);

            if (number.GetType() == typeof(int))
            {
                builder.Append(' ');
                builder.Append(Resources.String_Times);
            }
            else
            {
                builder.Append("%.");
            }

            return builder.ToString();
        }
    }
}
