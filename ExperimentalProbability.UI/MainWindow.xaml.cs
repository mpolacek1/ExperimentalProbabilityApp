using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;
using System;

namespace ExperimentalProbability.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LineValues = new ChartValues<double>();
            DataContext = this;
        }

        public ChartValues<double> LineValues { get; set; }

        private void ExpanderChart_Expanded(object sender, RoutedEventArgs e)
        {
            ExpanderChart.Header = "Collapse chart";
        }

        private void ExpanderChart_Collapsed(object sender, RoutedEventArgs e)
        {
            ExpanderChart.Header = "Expand chart";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            LineValues.Clear();
            CalculateAverageResult(int.Parse(SimulationAmountTextBox.Text));
        }

        private void CalculateAverageResult(int amountOfSimulations)
        {
            var random = new Random();
            for (int currenctSimulation = 0; currenctSimulation < amountOfSimulations; currenctSimulation++)
            {
                var randomNumber = random.NextDouble();
                LineValues.Add(randomNumber);
            }

            double dataSum = 0;
            for (int i = 0; i < LineValues.Count; i++)
            {
                dataSum += LineValues[i];
            }

            AverageResultTextBlock.Text = $"Average result = {Math.Round(dataSum / amountOfSimulations, 3)}";
        }
    }
}
