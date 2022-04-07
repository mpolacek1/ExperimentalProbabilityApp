using ExperimentalProbability.Calculations.Calculations.TwoDPlane;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.QuarterCircle;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.QuarterCircle
{
    public class QuarterCircleShellViewModel : BaseTwoDPlaneCalculationShellViewModel
    {
        public QuarterCircleShellViewModel()
            : base(Resources.DisplayName, new DescriptionViewModel(Resources.Function), typeof(QuarterCircleCalculation))
        {
        }
    }
}
