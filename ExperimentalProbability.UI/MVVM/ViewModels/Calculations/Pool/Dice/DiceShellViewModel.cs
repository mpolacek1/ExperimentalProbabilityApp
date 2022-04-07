using System.Collections.Generic;
using ExperimentalProbability.Calculations.Calculations.Pool;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.Dice;
using ExperimentalProbability.Contracts.Utilities;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice
{
    public class DiceShellViewModel : BasePoolCalculationShellViewModel
    {
        public DiceShellViewModel()
            : base(Resources.DisplayName, new PoolViewModel(), new ConditionViewModel(), new DescriptionViewModel(), typeof(DiceCalculation))
        {
        }

        public override CalculationData GetCalculationData()
        {
            var poolVM = (PoolViewModel)PoolVM;
            var diceType = poolVM.SelectedDiceType;

            return new DiceCalculationData(
                HeaderVM.Simulations.Value,
                diceType == null ? default : poolVM.DiceTypes[diceType],
                GetConditionSelectedSides());
        }

        public ConditionViewModel GetConditionVM()
        {
            return (ConditionViewModel)ConditionVM;
        }

        public DescriptionViewModel GetDescriptionVM()
        {
            return (DescriptionViewModel)DescriptionVM;
        }

        private int[] GetConditionSelectedSides()
        {
            var conditionVM = (ConditionViewModel)ConditionVM;
            var selectedSides = new List<int>(conditionVM.NumberOfRolls.Value);

            foreach (var item in conditionVM.Items)
            {
                var selectedSide = item.SelectedSide;

                selectedSides.Add(selectedSide == null ? default : NumberTranslater.WordToNumber[selectedSide]);
            }

            return selectedSides.ToArray();
        }
    }
}
