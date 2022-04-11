using System;
using System.Linq;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Shell;
using ExperimentalProbability.UI.MVVM.Models;
using ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane;
using ColoredBallsShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls.ShellViewModel;
using DiceShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice.ShellViewModel;
using PCCBResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.ColoredBalls.Resources;
using PCDResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.Dice.Resources;
using TDPCAResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Area.Resources;
using TDPCPResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.TwoDPlane.Pi.Resources;
using TResx = ExperimentalProbability.Contracts.Properties.Resources.Tutorial.Resources;

namespace ExperimentalProbability.UI.MVVM.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        public ShellViewModel()
        {
            ViewModelPlaceholders = GenerateVMPlaceholders();

            ActivateWantedVM(ViewModelPlaceholders[0].Type);
        }

        public ViewModelPlaceholder[] ViewModelPlaceholders { get; set; }

        public void MenuButtonClick(ViewModelPlaceholder menuItem)
        {
            foreach (var placeholder in ViewModelPlaceholders)
            {
                if (placeholder.Type != null && placeholder != menuItem)
                {
                    placeholder.IsShown = false;
                }
            }

            ActivateWantedVM(menuItem.Type);
        }

        public void ActivateWantedVM(Type vm)
        {
            var item = Items.Where(x => x.GetType() == vm).FirstOrDefault();

            if (item == null)
            {
                ActivateItem((Screen)Activator.CreateInstance(vm));
            }
            else
            {
                ActivateItem(item);
            }
        }

        private static ViewModelPlaceholder[] GenerateVMPlaceholders()
        {
            return new ViewModelPlaceholder[7]
            {
                new ViewModelPlaceholder(TResx.DisplayName, typeof(TutorialViewModel), true),
                new ViewModelPlaceholder(Resources.PoolCalcs),
                new ViewModelPlaceholder(PCCBResx.DisplayName, typeof(ColoredBallsShellVM)),
                new ViewModelPlaceholder(PCDResx.DisplayName, typeof(DiceShellVM)),
                new ViewModelPlaceholder(Resources.TwoDPlaneCalcs),
                new ViewModelPlaceholder(TDPCPResx.Function, typeof(PiShellViewModel)),
                new ViewModelPlaceholder(TDPCAResx.Function, typeof(AreaShellViewModel)),
            };
        }
    }
}
