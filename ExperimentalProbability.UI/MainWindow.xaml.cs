using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.UI.Controllers;
using ExperimentalProbability.UI.Validation;
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

        public string[] Colors { get; } = new string[9]
        {
            Properties.Resources.Color_Black,
            Properties.Resources.Color_White,
            Properties.Resources.Color_Red,
            Properties.Resources.Color_Green,
            Properties.Resources.Color_Blue,
            Properties.Resources.Color_Brown,
            Properties.Resources.Color_Orange,
            Properties.Resources.Color_Violet,
            Properties.Resources.Color_Yellow,
        };

        public void Selection_ColoredBalls_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateColorSelectionItemsSources();
        }

        private void Selection_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void ColoredBalls_NumberOfColors_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Panel_ColoredBalls_Selection_Color.Children.Clear();

            if (((IntegerUpDown)sender).Validate())
            {
                this.GenerateItemsSelection(Panel_ColoredBalls_Selection_Color.Children, ((IntegerUpDown)sender).Value.Value);
            }
        }

        private void Condition_NumberOfTakenItems_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var itemPanelChildren = Panel_Condition_Selection_Outcome.Children;
            itemPanelChildren.Clear();

            if (((IntegerUpDown)sender).Validate())
            {
                var numberOfItems = ((IntegerUpDown)sender).Value.Value;

                switch (Selection_Type.SelectedIndex)
                {
                    case 0:
                        this.GenerateItemsSelection(
                            itemPanelChildren,
                            numberOfItems,
                            Properties.Resources.Default_Selection_ColoredBalls,
                            this.GetColoredBallsSelectionItemsSource());

                        break;
                    case 1:
                        this.GenerateItemsSelection(
                            itemPanelChildren,
                            numberOfItems,
                            Properties.Resources.Default_Selection_Dice,
                            this.GetDiceSelectionItemsSource());

                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
