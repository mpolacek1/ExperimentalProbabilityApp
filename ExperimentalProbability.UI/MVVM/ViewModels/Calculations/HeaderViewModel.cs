using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Extensions;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations
{
    public class HeaderViewModel : Screen
    {
        private int? _sims;

        public HeaderViewModel()
        {
            _sims = MinSimulations;
        }

        public int? Simulations
        {
            get
            {
                return _sims;
            }

            set
            {
                _sims = value;
                NotifyOfPropertyChange(() => Simulations);
            }
        }

        public int MinSimulations => (int)GeneralNumbers.MinSimulations;

        public int MaxSimulations => (int)GeneralNumbers.MaxSimulations;

        public int MaxSimulationsLength => MaxSimulations.Length();
    }
}
