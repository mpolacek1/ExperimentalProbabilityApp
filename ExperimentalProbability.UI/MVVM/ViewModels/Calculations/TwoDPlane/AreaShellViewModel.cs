using ExperimentalProbability.Calculations.Calculations.TwoDPlane;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Area;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane
{
    public class AreaShellViewModel : BaseTwoDPlaneShellViewModel
    {
        public AreaShellViewModel()
            : base(Resources.Function, Resources.FullDescription, Resources.FinalResultName, typeof(AreaCalculation))
        {
        }
    }
}
