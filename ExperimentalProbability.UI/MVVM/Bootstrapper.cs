using Caliburn.Micro;
using ExperimentalProbability.UI.MVVM.ViewModels;
using System.Windows;

namespace ExperimentalProbability.UI.MVVM
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
