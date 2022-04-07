using Caliburn.Micro;
using ExperimentalProbability.Contracts.Extensions;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.Dice;
using ExperimentalProbability.Contracts.Utilities;
using GeneralPoolCalcResources = ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.General.Resources;
using GeneralResources = ExperimentalProbability.Contracts.Properties.Resources.General.Resources;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice
{
    public class DescriptionViewModel : Screen
    {
        private string _poolInfo;

        public DescriptionViewModel()
        {
            SelectedConditionSides = new BindableCollection<string>();
        }

        public string CalculationInfo
            => string.Concat(GeneralPoolCalcResources.Description_CalculationInfo, ' ', Resources.CalculationInfo);

        public string PoolInfo
        {
            get
            {
                return GetPoolInfo(_poolInfo);
            }

            set
            {
                _poolInfo = value;
                NotifyOfPropertyChange(() => PoolInfo);
            }
        }

        public BindableCollection<string> SelectedConditionSides { get; set; }

        public void AddSideToSelectedConditionSides(int position, string side = null)
        {
            var fullInfo = string.Concat(
                ' ',
                NumberTranslater.NumberToPosition[position],
                ' ',
                Resources.CalcAction,
                ' ',
                side ?? GeneralResources.NotAvailable,
                '.');

            SelectedConditionSides.RewriteOrAddItem(position, fullInfo);
        }

        private string GetPoolInfo(string poolInfo)
        {
            return string.Concat(
                GeneralPoolCalcResources.Description_PoolInfo,
                ' ',
                poolInfo ?? GeneralResources.NotAvailable,
                '.');
        }
    }
}
