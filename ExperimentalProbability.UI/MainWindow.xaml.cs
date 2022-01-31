using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.UI.Controllers;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string[] Types { get; } = new string[2]
        {
            Properties.Resources.Type_ColoredBalls,
            Properties.Resources.Type_Dice,
        };

        public string[] Colors { get; } = new string[10]
        {
            Properties.Resources.Color_Black,
            Properties.Resources.Color_White,
            Properties.Resources.Color_Red,
            Properties.Resources.Color_Green,
            Properties.Resources.Color_Blue,
            Properties.Resources.Color_Brown,
            Properties.Resources.Color_Gray,
            Properties.Resources.Color_Orange,
            Properties.Resources.Color_Violet,
            Properties.Resources.Color_Yellow,
        };

        public void Selection_ColoredBalls_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateColorSelectionItemsSources();
            this.UpdateOutcomeSelectorsItemsSource();
        }

        private void Selection_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Panel_Condition_Selection_Outcome.Children.Clear();

            switch (Selection_Type.SelectedIndex)
            {
                case 0:
                    this.UpdateColoredBallsControls(Visibility.Visible);
                    this.UpdateControlsToColoredBalls();

                    break;
                case 1:
                    this.UpdateColoredBallsControls(Visibility.Collapsed);
                    this.UpdateControlsToDice();

                    break;
                default:
                    break;
            }
        }

        private void Pool_Size_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (Selection_Type.SelectedItem.Equals(Properties.Resources.Type_Dice))
            {
                var itemPanels = Panel_Condition_Selection_Outcome.Children;

                for (int i = 0; i < itemPanels.Count; i++)
                {
                    ((ComboBox)((Panel)itemPanels[i]).Children[0]).ItemsSource = this.GetDiceSelectionItemsSource();
                }
            }
        }

        private void ColoredBalls_NumberOfColors_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var colorPanels = Panel_ColoredBalls_Selection_Color.Children;
            var numberOfColors = ((IntegerUpDown)sender).Value.Value;

            colorPanels.ClearNotNeededItemPanels(numberOfColors);

            this.GenerateItemsSelection(colorPanels, numberOfColors);

            this.UpdateColorSelectionItemsSources();
            this.UpdateOutcomeSelectorsItemsSource();
        }

        private void Condition_NumberOfTakenItems_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var itemPanels = Panel_Condition_Selection_Outcome.Children;
            var numberOfItems = ((IntegerUpDown)sender).Value.Value;

            itemPanels.ClearNotNeededItemPanels(numberOfItems);

            switch (Selection_Type.SelectedIndex)
            {
                case 0:
                    this.GenerateItemsSelection(
                        itemPanels,
                        numberOfItems,
                        Properties.Resources.Default_Selection_ColoredBalls,
                        Panel_ColoredBalls_Selection_Color.Children.GetCurrentSelectedItemsFromPanels(numberOfItems));

                    break;
                case 1:
                    this.GenerateItemsSelection(
                        itemPanels,
                        numberOfItems,
                        Properties.Resources.Default_Selection_Dice,
                        this.GetDiceSelectionItemsSource());

                    break;
                default:
                    break;
            }
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
