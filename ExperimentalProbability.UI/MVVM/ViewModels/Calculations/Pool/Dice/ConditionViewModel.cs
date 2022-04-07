using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Extensions;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice
{
    public class ConditionViewModel : Conductor<SidePickerViewModel>.Collection.AllActive
    {
        private int? _numberOfRolls;

        private string[] _selectableSides;

        public string[] SelectableSides
        {
            get
            {
                return _selectableSides;
            }

            set
            {
                _selectableSides = value;

                Items.Apply(item => item.SelectableSides = value);

                NotifyOfPropertyChange(() => SelectableSides);
            }
        }

        public int? NumberOfRolls
        {
            get
            {
                return _numberOfRolls;
            }

            set
            {
                _numberOfRolls = value;
                UpdateSideSelection(value.Value);
                NotifyOfPropertyChange(() => NumberOfRolls);
            }
        }

        public int MinNumberOfRolls => (int)DiceNumbers.MinNumberOfRolls;

        public int MaxNumberOfRolls => (int)DiceNumbers.MaxNumberOfRolls;

        public int MaxNumberOfRollsLength => MaxNumberOfRolls.Length();

        protected override void OnInitialize()
        {
            NumberOfRolls = (int)DiceNumbers.MinNumberOfRolls;
        }

        private void UpdateSideSelection(int numberOfThrows)
        {
            if (numberOfThrows < Items.Count)
            {
                for (int i = Items.Count - 1; i >= numberOfThrows; i--)
                {
                    Items.RemoveAt(i);
                    GetDescriptionVM().SelectedConditionSides.RemoveAt(i);
                }
            }
            else if (numberOfThrows > Items.Count)
            {
                for (int i = Items.Count; i < numberOfThrows; i++)
                {
                    ActivateItem(new SidePickerViewModel(i, SelectableSides));
                    GetDescriptionVM().AddSideToSelectedConditionSides(i);
                }
            }
        }

        private DescriptionViewModel GetDescriptionVM()
        {
            return ((DiceShellViewModel)Parent).GetDescriptionVM();
        }
    }
}
