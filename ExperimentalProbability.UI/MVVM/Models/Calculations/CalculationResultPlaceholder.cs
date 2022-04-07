using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.General;

namespace ExperimentalProbability.UI.MVVM.Models.Calculations
{
    public abstract class CalculationResultPlaceholder : PropertyChangedBase
    {
        private readonly string _position;

        private object _result;

        public CalculationResultPlaceholder(int position)
        {
            _position = string.Concat(position, '.');
        }

        public string Position => _position;

        public object Result
        {
            get
            {
                return _result ?? Resources.NotAvailable;
            }

            set
            {
                _result = value;
                NotifyOfPropertyChange(() => FormattedResult);
            }
        }

        public string FormattedResult => GetFormattedResult();

        public abstract string GetFormattedResult();
    }
}
