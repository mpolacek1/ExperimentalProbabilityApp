using ExperimentalProbability.Calculations.Calculations.TwoDPlane;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Pi;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.Pi
{
    public class ShellViewModel : BaseTwoDPlaneShellViewModel
    {
        public ShellViewModel()
            : base(Resources.DisplayName, new DescriptionViewModel(Resources.Function), Resources.FinalResultName, typeof(PiCalculation))
        {
        }
    }
}
