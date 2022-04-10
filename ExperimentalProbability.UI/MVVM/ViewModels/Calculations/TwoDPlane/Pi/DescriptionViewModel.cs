using Caliburn.Micro;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.Pi
{
    public class DescriptionViewModel : Screen
    {
        private readonly string _function;

        public DescriptionViewModel(string function)
        {
            _function = function;
        }

        public string Function => _function;
    }
}
