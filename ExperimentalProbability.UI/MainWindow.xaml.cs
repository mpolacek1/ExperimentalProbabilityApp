using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.Calculations.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        private readonly string[] Types = new string[2]
        {
            Properties.Resources.Type_ColoredBalls,
            Properties.Resources.Type_Dice,
        };

        private readonly string[] Colors = new string[9]
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
            Title = Properties.Resources.MainWindow_Title;
            UpdateCalculationSettingsControls();
            Button_Run.Content = Properties.Resources.Button_Run;
        }

        private void UpdateCalculationSettingsControls()
        {
            Header1_Settings_Calculation.Text = Properties.Resources.Header1_Settings_Calculation;
            Text_Simulations.Text = Properties.Resources.Text_Simulations;
            Simulations.Text = Properties.Resources.Default_Simulations;

            Header2_Settings_Type.Text = Properties.Resources.Header2_Settings_Type;
            Selection_Type.Text = Properties.Resources.Text_Selection_Type;
            Selection_Type.ItemsSource = Types;

            Header3_Settings_Pool.Text = Properties.Resources.Header3_Settings_Pool;

            Header2_Settings_Condition.Text = Properties.Resources.Header2_Settings_Condition;
        }

        private void Selection_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Selection_Type.SelectedIndex)
            {
                default:
                    Button_Run.IsEnabled = false;
                    Panel_Settings_Pool_ColoredBalls.Visibility = Visibility.Collapsed;
                    break;
                case 0:
                    UpdateCurrentTypeControls(
                        Properties.Resources.Text_Pool_Size_ColoredBalls,
                        Properties.Resources.Default_Pool_Size_ColoredBalls,
                        Visibility.Visible,
                        new Thickness(0, 0, 1, 0),
                        new Thickness(0, 0, 10, 0),
                        Dock.Right,
                        Properties.Resources.Text_Condition_ColoredBalls_NumberOfTakenItems,
                        Properties.Resources.Default_Condition_ColoredBalls_NumberOfTakenItems
                    );
                    Text_ColoredBalls_NumberOfColors.Text = Properties.Resources.Text_ColoredBalls_NumberOfColors;
                    ColoredBalls_NumberOfColors.Text = Properties.Resources.Default_ColoredBalls_NumberOfColors;
                    ColoredBalls_Check_EqualNumberOfColors.Content = Properties.Resources.Text_ColoredBalls_Check_EqualNumberOfColors;
                    ColoredBalls_Check_EqualNumberOfColors.IsChecked = false;
                    break;
                case 1:
                    UpdateCurrentTypeControls(
                        Properties.Resources.Text_Pool_Size_Dice,
                        Properties.Resources.Default_Pool_Size_Dice,
                        Visibility.Collapsed,
                        new Thickness(0, 0, 0, 1),
                        new Thickness(0),
                        Dock.Bottom,
                        Properties.Resources.Text_Condition_Dice_NumberOfTakenItems,
                        Properties.Resources.Default_Condition_Dice_NumberOfTakenItems
                    );
                    break;
            }
        }

        private void UpdateCurrentTypeControls(string poolText, string poolSize, Visibility visibilityColoredBalls, Thickness borderThickness, Thickness marginAndPadding, Dock dock, string textNumberOfTakenItems, string defaultNumberOfTakenItems)
        {
            Border_Settings_Pool_Size.Visibility = Visibility.Visible;
            Text_Pool_Size.Text = poolText;
            Pool_Size.Text = poolSize;
            Panel_Settings_Pool_ColoredBalls.Visibility = visibilityColoredBalls;
            Border_Settings_Type.BorderThickness = borderThickness;
            Border_Settings_Type.Margin = marginAndPadding;
            Border_Settings_Type.Padding = marginAndPadding;
            DockPanel.SetDock(Panel_Settings_Condition, dock);
            Panel_Settings_Condition.Visibility = Visibility.Visible;
            Text_Condition_NumberOfTakenItems.Text = textNumberOfTakenItems;
            Condition_NumberOfTakenItems.Text = defaultNumberOfTakenItems;
            Button_Run.IsEnabled = true;
        }

        private void Pool_Size_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Selection_Type.SelectedIndex == 1)
            {
                GenerateSelectionChildrenForPanel(
                    Condition_NumberOfTakenItems,
                    Panel_Condition_Selection_Outcome,
                    GetCurrentItemText(Selection_Type.SelectedIndex),
                    GetCurrentSelectionText(Selection_Type.SelectedIndex),
                    GetCurrentItemsSource(Selection_Type.SelectedIndex)
                );
            }
        }

        private void ColoredBalls_NumberOfColors_TextChanged(object sender, TextChangedEventArgs e)
        {
            GenerateSelectionChildrenForPanel(
                ColoredBalls_NumberOfColors,
                Panel_ColoredBalls_Selection_Color,
                Properties.Resources.Text_ColoredBalls_Color,
                Properties.Resources.Text_Selection_ColoredBalls_Color,
                Colors
            );
        }

        private void Condition_NumberOfTakenItems_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Selection_Type.SelectedIndex != -1)
            {
                GenerateSelectionChildrenForPanel(
                    Condition_NumberOfTakenItems,
                    Panel_Condition_Selection_Outcome,
                    GetCurrentItemText(Selection_Type.SelectedIndex),
                    GetCurrentSelectionText(Selection_Type.SelectedIndex),
                    GetCurrentItemsSource(Selection_Type.SelectedIndex)
                );
            }
        }

        private static string GetCurrentItemText(int selectedType) => selectedType switch
        {
            0 => Properties.Resources.Text_ColoredBalls_Color,
            1 => Properties.Resources.Text_Dice_Side,
            _ => throw new ArgumentOutOfRangeException(nameof(selectedType), $"{selectedType}"),
        };

        private static string GetCurrentSelectionText(int selectedType) => selectedType switch
        {
            0 => Properties.Resources.Text_Selection_ColoredBalls_Color,
            1 => Properties.Resources.Text_Selection_Dice_Side,
            _ => throw new ArgumentOutOfRangeException(nameof(selectedType), $"{selectedType}"),
        };

        private IConvertible[] GetCurrentItemsSource(int selectedType) => selectedType switch
        {
            0 => GetColoredBallsItemSource(),
            1 => GetDiceItemSource(int.TryParse(Pool_Size.Text, out int numberOfSides) ? numberOfSides : 0),
            _ => throw new ArgumentOutOfRangeException(nameof(selectedType), $"{selectedType}"),
        };

        private IConvertible[] GetColoredBallsItemSource()
        {
            var chosenColors = new List<IConvertible>();

            foreach (StackPanel panelChild in Panel_ColoredBalls_Selection_Color.Children)
            {
                foreach (ComboBox child in panelChild.Children)
                {
                    if (chosenColors.Contains(Colors[child.SelectedIndex]) == false)
                    {
                        chosenColors.Add(Colors[child.SelectedIndex]);
                    }
                }
            }

            return chosenColors.ToArray();
        }

        private static IConvertible[] GetDiceItemSource(int numberOfSides)
        {
            var sides = new IConvertible[numberOfSides];

            for (int i = 0; i < numberOfSides; i++)
            {
                sides[i] = i + 1;
            }

            return sides;
        }

        private static void GenerateSelectionChildrenForPanel(TextBox sender, Panel currentPanel, string itemText, string selectionText, IConvertible[] itemsSource)
        {
            currentPanel.Children.Clear();

            if (sender.Text != string.Empty
                && int.TryParse(sender.Text, out int numberOfItems) == true)
            {
                for (int i = 0; i < numberOfItems; i++)
                {
                    var builder = new StringBuilder(itemText);
                    builder.Append(' ');
                    builder.Append(i + 1);
                    builder.Append(':');

                    var textBlock = new TextBlock()
                    {
                        Text = builder.ToString(),
                        Margin = new Thickness(0, 0, 5, 0),
                    };

                    var comboBox = new ComboBox()
                    {
                        IsEditable = true,
                        IsReadOnly = true,
                        Text = selectionText,
                        ItemsSource = itemsSource,
                    };

                    var stackPanel = new StackPanel()
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(0, 0, 0, 5),
                    };
                    stackPanel.Children.Add(textBlock);
                    stackPanel.Children.Add(comboBox);

                    currentPanel.Children.Add(stackPanel);
                }
            }
        }

        private void Button_Run_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private static void DisplayResult(CalculationResultData result)
        {
            BuildResultText(Properties.Resources.Text_SimulationsRun, result.SimulationsRun);
            BuildResultText(Properties.Resources.Text_ConditionsMet, result.ConditionsMet);
            BuildResultText(Properties.Resources.Text_Probability, result.Probability);
        }

        private static string BuildResultText(string text, IConvertible number)
        {
            var builder = new StringBuilder(text);
            builder.Append(' ');
            builder.Append(number);

            if (number.GetType() == typeof(int))
            {
                builder.Append(' ');
                builder.Append(Properties.Resources.String_Times);
            }
            else
            {
                builder.Append("%.");
            }

            return builder.ToString();
        }
    }
}
