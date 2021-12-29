using ExperimentalProbability.Calculations.Models;
using ExperimentalProbability.Calculations.Types;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        private readonly string[] Types = new string[3]
        {
            Properties.Resources.Type_Empty,
            Properties.Resources.Type_BagOfColoredBalls,
            Properties.Resources.Type_DiceRoll,
        };

        private readonly string[] Empty_Conditions = new string[1]
        {
            Properties.Resources.Condition_NotAvailable,
        };

        private readonly string[] BagOfColoredBalls_Conditions = new string[2]
        {
            Properties.Resources.BagOfColoredBalls_Condition_First,
            Properties.Resources.BagOfColoredBalls_Condition_Second,
        };

        private readonly string[] DiceRoll_Conditions = new string[2]
        {
            Properties.Resources.DiceRoll_Condition_First,
            Properties.Resources.DiceRoll_Condition_Second,
        };

        public MainWindow()
        {
            InitializeComponent();
            UpdateControlsContent();
        }

        private void UpdateControlsContent()
        {
            Header_Settings.Text = Properties.Resources.Header_Settings;
            Text_Type.Text = Properties.Resources.Text_Type;
            Box_Types.ItemsSource = Types;
            Text_Condition.Text = Properties.Resources.Text_Condition;
            Text_Simulations.Text = Properties.Resources.Text_Simulations;
            NumberOfSimulations.Text = Properties.Resources.Simulations_Default;

            Header_Description.Text = Properties.Resources.Header_Description;
            Header_Description_Type.Text = Properties.Resources.Header_Description_Type;
            Header_Description_Condition.Text = Properties.Resources.Header_Description_Condition;

            Header_Results.Text = Properties.Resources.Header_Results;

            Button_Run.Content = Properties.Resources.Button_Run;
        }

        private void Box_Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] itemsSource = Empty_Conditions;
            string descriptionType = "";
            bool buttonEnabled = false;

            switch (Box_Types.SelectedIndex)
            {
                case 1:
                    itemsSource = BagOfColoredBalls_Conditions;
                    descriptionType = Properties.Resources.Desription_BagOfColoredBalls;
                    buttonEnabled = true;
                    break;
                case 2:
                    itemsSource = DiceRoll_Conditions;
                    descriptionType = Properties.Resources.Description_DiceRoll;
                    buttonEnabled = true;
                    break;
            }

            Description_Type.Text = descriptionType;
            Box_Conditions.ItemsSource = itemsSource;
            Box_Conditions.SelectedIndex = 0;
            Button_Run.IsEnabled = buttonEnabled;
        }

        private void Box_Conditions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Box_Types.SelectedIndex)
            {
                case 1:
                    Description_Condition.Text = GetConditionDescription(new string[2]
                    {
                        Properties.Resources.Description_BagOfColoredBalls_Condition_First,
                        Properties.Resources.Description_BagOfColoredBalls_Condition_Second,
                    });
                    break;
                case 2:
                    Description_Condition.Text = GetConditionDescription(new string[2]
                    {
                        Properties.Resources.Description_DiceRoll_Condition_First,
                        Properties.Resources.Description_DiceRoll_Condition_Second,
                    });
                    break;
            }
        }

        private string GetConditionDescription(string[] descriptions)
        {
            string description = descriptions[0];

            if (Box_Conditions.SelectedIndex == 1)
            {
                description = descriptions[1];
            }

            return description;
        }

        private async void Button_Run_Click(object sender, RoutedEventArgs e)
        {
            await DisplayResult(await RunCalculation(
                new CalculationData(
                    Box_Types.SelectedIndex,
                    Box_Conditions.SelectedIndex,
                    int.Parse(NumberOfSimulations.Text))));
        }

        private async Task<CalculationResultData> RunCalculation(CalculationData data)
        {
            IType calculation = null;

            switch (data.Type)
            {
                case 1:
                    calculation = new BagOfColoredBalls();
                    break;
                case 2:
                    calculation = new DiceRoll(data.Condition);
                    break;
            }

            return await calculation.Calculate(data.Condition, data.Simulations);
        }

        private async Task DisplayResult(CalculationResultData result)
        {
            Text_SimulationsRun.Text = await BuildResultText(Properties.Resources.Text_SimulationsRun, result.SimulationsRun);
            Text_ConditionsMet.Text = await BuildResultText(Properties.Resources.Text_ConditionsMet, result.ConditionsMet);
            Text_Probability.Text = await BuildResultText(Properties.Resources.Text_Probability, result.Probability);
        }

        private Task<string> BuildResultText(string text, IConvertible number)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(text);
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

            return Task.FromResult(builder.ToString());
        }
    }
}
