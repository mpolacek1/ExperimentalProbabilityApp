using Caliburn.Micro;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane
{
    public class DescriptionViewModel : Screen
    {
        private readonly string _function;

        private readonly string _fullDescription;

        public DescriptionViewModel(string function, string fullDesc)
        {
            _function = function;
            _fullDescription = fullDesc;
        }

        public string Function => _function;

        public string FullDescription => _fullDescription;
    }
}
