using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.General;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations
{
    public class FooterViewModel : Screen
    {
        private int _progress;

        private string _buttonContent;

        public FooterViewModel()
        {
            _progress = (int)GeneralNumbers.MinProgress;
            _buttonContent = Resources.Footer_RunCalculation;
        }

        public int Progress
        {
            get
            {
                return _progress;
            }

            set
            {
                _progress = value;
                NotifyOfPropertyChange(() => Progress);
            }
        }

        public string ButtonContent
        {
            get
            {
                return _buttonContent;
            }

            set
            {
                _buttonContent = value;
                NotifyOfPropertyChange(() => ButtonContent);
            }
        }

        public void Calculate()
        {
            Progress = default;

            var baseCalcVM = (BaseCalculationShellViewModel)Parent;

            if (baseCalcVM.Worker.IsBusy)
            {
                ButtonContent = Resources.Footer_RunCalculation;

                baseCalcVM.Worker.CancelAsync();
            }
            else
            {
                ButtonContent = Resources.Footer_CancelCalculation;
                baseCalcVM.ResultsVM.ClearResults();

                baseCalcVM.CalculationData = baseCalcVM.GetCalculationData();
                baseCalcVM.Worker.RunWorkerAsync();
            }
        }
    }
}
