using System;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.General;
using ExperimentalProbability.UI.MVVM.Models.Calculations;
using LiveCharts;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations
{
    public class ResultsViewModel : Screen
    {
        private readonly string _resultName;

        private string _finalResult;

        public ResultsViewModel(string resultName, BindableCollection<CalculationResultPlaceholder> results)
        {
            _resultName = resultName;
            Results = results;
            ChartResults = new ChartValues<decimal>();
        }

        public BindableCollection<CalculationResultPlaceholder> Results { get; private set; }

        public string ResultName => _resultName;

        public string FinalResult
        {
            get
            {
                return _finalResult ?? Resources.NotAvailable;
            }

            set
            {
                _finalResult = value;
                NotifyOfPropertyChange(() => FinalResult);
            }
        }

        public ChartValues<decimal> ChartResults { get; private set; }

        public void UpdateProgressResults(int resultIndex, decimal result)
        {
            Results[resultIndex].Result = result.ToString();
            ChartResults.Add(result);
        }

        public decimal CalculateFinalResult()
        {
            var finalResult = default(decimal);

            foreach (var resultPlaceholder in Results)
            {
                finalResult += Convert.ToDecimal(resultPlaceholder.Result);
            }

            return finalResult;
        }

        public void ClearResults()
        {
            ChartResults.Clear();
            FinalResult = null;

            foreach (var result in Results)
            {
                result.Result = null;
            }
        }
    }
}
