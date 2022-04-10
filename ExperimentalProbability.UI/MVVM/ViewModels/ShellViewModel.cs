using System;
using System.Linq;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Properties.Resources.Shell;
using ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls;
using ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice;
using ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane.QuarterCircle;

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
            ActivateWantedVM(typeof(Calculations.Pool.ColoredBalls.ShellViewModel));
        }

        public void ShowDiceCalc()
        {
            ActivateWantedVM(typeof(Calculations.Pool.Dice.ShellViewModel));
        }

        public void ShowQuarterCircleCalc()
        {
            ActivateWantedVM(typeof(Calculations.TwoDPlane.QuarterCircle.ShellViewModel));
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
