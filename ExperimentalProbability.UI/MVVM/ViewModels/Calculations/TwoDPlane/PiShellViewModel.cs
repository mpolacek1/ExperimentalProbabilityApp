using ExperimentalProbability.Calculations.Calculations.TwoDPlane;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Pi;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane
{
    public class PiShellViewModel : BaseTwoDPlaneShellViewModel
    {
        public PiShellViewModel()
            : base(Resources.Function, Resources.FullDescription, Resources.FinalResultName, typeof(PiCalculation))
        {
        }
    }
}
