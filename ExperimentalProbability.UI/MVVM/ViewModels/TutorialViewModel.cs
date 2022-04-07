using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Tutorial;

namespace ExperimentalProbability.UI.MVVM.ViewModels
{
    public class TutorialViewModel : Screen
    {
        public TutorialViewModel()
        {
            DisplayName = Resources.DisplayName;
        }
    }
}
