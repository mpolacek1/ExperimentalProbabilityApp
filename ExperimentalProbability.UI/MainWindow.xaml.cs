using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.UI.Controllers;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        public readonly string[] Types = new string[2]
        {
            Properties.Resources.Type_ColoredBalls,
            Properties.Resources.Type_Dice,
        };

        public readonly string[] Colors = new string[9]
        {
            Properties.Resources.Color_Black,
            Properties.Resources.Color_Brown,
            Properties.Resources.Color_White,
            Properties.Resources.Color_Red,
            Properties.Resources.Color_Orange,
            Properties.Resources.Color_Yellow,
            Properties.Resources.Color_Green,
            Properties.Resources.Color_Blue,
            Properties.Resources.Color_Violet,
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.UpdateWindowControls();
        }

        private void Selection_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Selection_Type.SelectedIndex)
            {
                case 0:
                    this.UpdateControlsToColoredBalls();
                    this.UpdateColoredBallsControls(Visibility.Visible);

                    break;
                case 1:
                    this.UpdateControlsToDice();
                    this.UpdateColoredBallsControls(Visibility.Collapsed);

                    break;
            }
        }

        private void ColoredBalls_NumberOfColors_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.GenerateItemsSelection(Panel_ColoredBalls_Selection_Color.Children, ((TextBox)sender).Text);
        }

        public void Selection_ColoredBalls_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateColorSelectionItemsSources();
        }

        private void Condition_NumberOfTakenItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (Selection_Type.SelectedIndex)
            {
                case 0:
                    this.GenerateItemsSelection(
                        Panel_Condition_Selection_Outcome.Children,
                        ((TextBox)sender).Text,
                        Properties.Resources.Default_Selection_ColoredBalls,
                        this.GetColoredBallsSelectionItemsSource()
                    );

                    break;
                case 1:
                    this.GenerateItemsSelection(
                        Panel_Condition_Selection_Outcome.Children,
                        ((TextBox)sender).Text,
                        Properties.Resources.Default_Selection_Dice,
                        this.GetDiceSelectionItemsSource()
                    );
                    
                    break;
            }
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
