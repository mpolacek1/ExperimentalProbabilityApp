using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.Calculations.Types;
using ExperimentalProbability.UI.CustomControls;
using ExperimentalProbability.UI.Properties;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ExperimentalProbability.UI.Controllers
{
    public static class MainWindowController
    {
        public static void UpdateControlsBasedOnCurrentType(this MainWindow window, string poolText, string poolSize, string textNumberOfTakenItems, string defaultNumberOfTakenItems)
        {
            UpdateContent(window, poolText, poolSize, textNumberOfTakenItems, defaultNumberOfTakenItems);
            UpdateVisibility(window, Visibility.Visible);

            window.Button_Run.IsEnabled = true;
        }

        private static void UpdateContent(MainWindow window, string poolText, string poolSize, string textNumberOfTakenItems, string defaultNumberOfTakenItems)
        {
            window.Text_Pool_Size.Text = poolText;
            window.Pool_Size.Text = poolSize;
            window.Text_Condition_NumberOfTakenItems.Text = textNumberOfTakenItems;
            window.Condition_NumberOfTakenItems.Text = defaultNumberOfTakenItems;
        }

        private static void UpdateVisibility(MainWindow window, Visibility visibility)
        {
            window.Panel_Settings_Type.Visibility = visibility;
            window.Panel_Settings_Condition.Visibility = visibility;
        }

        public static void GenerateItemsSelection(this MainWindow window, UIElementCollection itemPanelChildren, string itemAmount, string text = null, string[] itemsSource = null)
        {
            itemPanelChildren.Clear();

            if (int.TryParse(itemAmount, out int numberOfItems)
                && numberOfItems > 0)
            {
                for (int i = 0; i < numberOfItems; i++)
                {
                    itemPanelChildren.Add(GetItemSelectionPanel(window, text, itemsSource));
                }
            }
        }

        private static Panel GetItemSelectionPanel(MainWindow window, string text, string[] itemsSource)
        {
            if (itemsSource != null)
            {
                return new ItemSelectionPanel(window, text, itemsSource);
            }
            
            return new ItemSelectionPanel(window);
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
