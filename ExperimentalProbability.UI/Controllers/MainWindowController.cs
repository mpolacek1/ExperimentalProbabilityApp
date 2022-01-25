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
        public static void UpdateWindowControls(this MainWindow window)
        {
            window.Title = Resources.MainWindow_Title;
            UpdateCalculationSettingsControls(window);
            window.Button_Run.Content = Resources.Button_Run;
        }

        private static void UpdateCalculationSettingsControls(MainWindow window)
        {
            window.Header1_Settings_Calculation.Text = Resources.Header1_Settings_Calculation;
            window.Text_Simulations.Text = Resources.Text_Simulations;
            window.Simulations.Text = Resources.Default_Simulations;

            window.Text_Selection_Type.Text = Resources.Text_Selection_Type;
            window.Selection_Type.Text = Resources.Default_Selection_Type;
            window.Selection_Type.ItemsSource = window.Types;

            window.Header2_Settings_Type.Text = Resources.Header2_Settings_Type;
            window.Text_ColoredBalls_NumberOfColors.Text = Resources.Text_ColoredBalls_NumberOfColors;
            window.ColoredBalls_NumberOfColors.Text = Resources.Default_ColoredBalls_NumberOfColors;

            window.Header2_Settings_Condition.Text = Resources.Header2_Settings_Condition;
        }

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
            window.Header2_Settings_Type.Visibility = visibility;
            window.Text_Pool_Size.Visibility = visibility;
            window.Pool_Size.Visibility = visibility;
            window.Text_ColoredBalls_NumberOfColors.Visibility = visibility;
            window.ColoredBalls_NumberOfColors.Visibility = visibility;
            window.Panel_ColoredBalls_Selection_Color.Visibility = visibility;
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
