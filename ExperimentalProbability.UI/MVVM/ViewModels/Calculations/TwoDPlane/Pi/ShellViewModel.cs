using ExperimentalProbability.Calculations.Calculations.TwoDPlane;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Pi;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.QuarterCircle
{
    public class ShellViewModel : BaseTwoDPlaneCalculationShellViewModel
    {
        public ShellViewModel()
            : base(Resources.DisplayName, new DescriptionViewModel(Resources.Function), typeof(QuarterCircleCalculation))
        {
        }
    }
}
