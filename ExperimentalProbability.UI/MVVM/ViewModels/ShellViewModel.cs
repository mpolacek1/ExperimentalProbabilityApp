using System;
using System.Linq;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Shell;
using ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane;
using ColoredBallsShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls.ShellViewModel;
using DiceShellVM = ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice.ShellViewModel;

namespace ExperimentalProbability.UI.MVVM.ViewModels
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
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
            ActivateWantedVM(typeof(PiShellViewModel));
        }

        public void ShowAreaCalc()
        {
            ActivateWantedVM(typeof(AreaShellViewModel));
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
    }
}
