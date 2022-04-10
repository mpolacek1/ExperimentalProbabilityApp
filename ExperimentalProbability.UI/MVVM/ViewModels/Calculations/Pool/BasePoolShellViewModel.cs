using System;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.General;
using ExperimentalProbability.UI.MVVM.Models.Calculations.Pool;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool
{
    public abstract class BasePoolShellViewModel : BaseShellViewModel
    {
        public BasePoolShellViewModel(string displayName, Screen poolVM, Screen conditionVM, Screen descriptionVM, Type calcType)
            : base(displayName, descriptionVM, Resources.Result_FinalResult_Probability, typeof(PoolCalculationResultPlaceholder), calcType)
        {
            PoolVM = poolVM;
            ConditionVM = conditionVM;
        }

        public Screen PoolVM { get; set; }

        public Screen ConditionVM { get; set; }

        protected override string CalculateFinalResult()
        {
            return string.Concat(ResultsVM.CalculateFinalResult() / ResultsVM.Results.Count * 100, " %");
        }

        protected override void OnInitialize()
        {
            ActivateItem(PoolVM);
            ActivateItem(ConditionVM);

            base.OnInitialize();
        }
    }
}
