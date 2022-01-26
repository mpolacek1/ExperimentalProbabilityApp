using System.Collections.Generic;
using ExperimentalProbability.UI.Properties;

namespace ExperimentalProbability.UI.Controllers
{
    public static class DiceController
    {
        public static void UpdateControlsToDice(this MainWindow window)
        {
            window.UpdateControlsBasedOnCurrentType(
                Resources.Text_Pool_Size_Dice,
                Resources.Default_Pool_Size_Dice,
                Resources.Text_Condition_Dice_NumberOfTakenItems,
                Resources.Default_Condition_Dice_NumberOfTakenItems);
        }

        public static string[] GetDiceSelectionItemsSource(this MainWindow window)
        {
            if (int.TryParse(window.Pool_Size.Text, out int numberOfSides)
                && numberOfSides > 0)
            {
                var itemsSource = new List<string>(numberOfSides);

                for (int i = 1; i <= numberOfSides; i++)
                {
                    itemsSource.Add(i.ToString());
                }

                return itemsSource.ToArray();
            }

            return new string[0];
        }
    }
}
