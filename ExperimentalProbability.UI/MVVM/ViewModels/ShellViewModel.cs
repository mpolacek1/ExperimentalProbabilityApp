using System;
using System.Linq;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Shell;
using ColoredBallsShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls.ShellViewModel;
using DiceShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice.ShellViewModel;
using PiShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.Pi.ShellViewModel;

namespace ExperimentalProbability.UI.MVVM.ViewModels
{
    public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        public ShellViewModel()
        {
            DisplayName = Resources.DisplayName;

            ShowTutorial();
        }

        public void ShowTutorial()
        {
            ActivateWantedVM(typeof(TutorialViewModel));
        }

        public void ShowColoredBallsCalc()
        {
            ActivateWantedVM(typeof(ColoredBallsShellVM));
        }

        public void ShowDiceCalc()
        {
            ActivateWantedVM(typeof(DiceShellVM));
        }

        public void ShowPiCalc()
        {
            ActivateWantedVM(typeof(PiShellVM));
        }

        public void ActivateWantedVM(Type vm)
        {
            var item = Items.Where(x => x.GetType() == vm).FirstOrDefault();

            if (item == null)
            {
                ActivateItem(Activator.CreateInstance(vm));
            }
            else
            {
                ActivateItem(item);
            }
        }
    }
}
