using System;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.General;
using ExperimentalProbability.UI.MVVM.Models.Calculations.TwoDPlane;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane
{
    public abstract class BaseTwoDPlaneShellViewModel : BaseShellViewModel
    {
        public BaseTwoDPlaneShellViewModel(string funcPrefix, string fullDesc, string finalResultName, Type calcType)
            : base(string.Concat(Resources.DisplayName, ' ', funcPrefix), new DescriptionViewModel(funcPrefix, fullDesc), finalResultName, typeof(TwoDPlaneCalculationResultPlaceholder), calcType)
        {
        }

        public override CalculationData GetCalculationData()
        {
            return new CalculationData(HeaderVM.Simulations.Value);
        }

        protected override string CalculateFinalResult()
        {
            return (ResultsVM.CalculateFinalResult() / ResultsVM.Results.Count).ToString();
        }
    }
}
