using System.Collections.Generic;
using System.Windows;
using ExperimentalProbability.UI.Properties;

namespace ExperimentalProbability.UI.Controllers
{
    public static class DiceController
    {
        public static void UpdateControlsToDice(this MainWindow window)
        {
            window.UpdateControlsBasedOnCurrentType(
                Resources.Text_Pool_Size_Dice,
                (Style)Application.Current.Resources["IntegerUpDownDicePoolSize"],
                Resources.Text_Condition_Dice_NumberOfTakenItems,
                Resources.Default_Condition_Dice_NumberOfTakenItems);
        }

        public static List<string> GetDiceSelectionItemsSource(this MainWindow window)
        {
            int numberOfSides = window.Pool_Size.Value.Value;
            var itemsSource = new List<string>(numberOfSides);

            for (int i = 1; i <= numberOfSides; i++)
            {
                itemsSource.Add(i.ToString());
            }

            return itemsSource;
        }

        public static void RunDiceCalculationAndDisplayResult(this MainWindow window)
        {
        }
    }
}
