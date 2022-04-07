using System.Collections.Generic;
using ExperimentalProbability.Calculations.Calculations.Pool;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.ColoredBalls;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class ColoredBallsShellViewModel : BasePoolCalculationShellViewModel
    {
        public ColoredBallsShellViewModel()
            : base(Resources.DisplayName, new PoolViewModel(), new ConditionViewModel(), new DescriptionViewModel(), typeof(ColoredBallsCalculation))
        {
        }

        public PoolViewModel GetPoolVM()
        {
            return (PoolViewModel)PoolVM;
        }

        public ConditionViewModel GetConditionVM()
        {
            return (ConditionViewModel)ConditionVM;
        }

        public DescriptionViewModel GetDescriptionVM()
        {
            return (DescriptionViewModel)DescriptionVM;
        }

        public override CalculationData GetCalculationData()
        {
            var poolData = GetPoolData();

            return new ColoredBallsCalculationData(
                HeaderVM.Simulations.Value,
                ((PoolViewModel)PoolVM).NumberOfBalls.Value,
                (object[])poolData[0],
                (int[])poolData[1],
                GetConditionColors(),
                GetDescriptionVM().Bag);
        }

        public object[] GetPoolData()
        {
            var poolVM = (PoolViewModel)PoolVM;
            var colors = new List<object>(poolVM.Items.Count);
            var counts = new List<int>(poolVM.Items.Count);

            foreach (var item in poolVM.Items)
            {
                colors.Add(item.ActiveItem.SelectedColor);
                counts.Add(item.Count.Value);
            }

            return new object[2]
            {
                colors.ToArray(),
                counts.ToArray(),
            };
        }

        private object[] GetConditionColors()
        {
            var conditiomVM = (ConditionViewModel)ConditionVM;
            var colors = new List<object>(conditiomVM.Items.Count);

            foreach (var item in conditiomVM.Items)
            {
                colors.Add(item.SelectedColor);
            }

            return colors.ToArray();
        }
    }
}
