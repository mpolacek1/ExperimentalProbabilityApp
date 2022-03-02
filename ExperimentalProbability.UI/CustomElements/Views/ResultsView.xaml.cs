using ExperimentalProbability.Calculation.Models;
using System.Windows.Controls;

namespace ExperimentalProbability.UI.CustomElements.Views
{
    public partial class ResultsView : UserControl
    {
        public ResultsView()
        {
            InitializeComponent();
        }

        public void DisplayResult(CalculationResultData result)
        {
            ((TextBlock)((Panel)ResultsTable.Children[0]).Children[0]).Text = result.SimulationsRun.ToString();
            ((TextBlock)((Panel)ResultsTable.Children[0]).Children[1]).Text = result.ConditionMet.ToString();
            ((TextBlock)((Panel)ResultsTable.Children[0]).Children[2]).Text = result.Probability.ToString();
        }
    }
}
