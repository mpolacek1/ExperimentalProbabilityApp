using Caliburn.Micro;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.MVVM.Views.Calculations.Pool.Dice;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice
{
    public class SidePickerViewModel : Screen
    {
        private readonly int _position;

        private string[] _selectableSides;

        private string _selectedSide;

        public SidePickerViewModel(int position, string[] selectableSides)
        {
            _position = position;
            SelectableSides = selectableSides;
        }

        public string[] SelectableSides
        {
            get
            {
                return _selectableSides;
            }

            set
            {
                _selectableSides = value;
                NotifyOfPropertyChange(() => SelectableSides);
            }
        }

        public string SelectedSide
        {
            get
            {
                return _selectedSide;
            }

            set
            {
                ((SidePickerView)GetView()).SidePickerLabel.HideOrShow(value);

                ((DiceShellViewModel)((ConditionViewModel)Parent).Parent)
                    .GetDescriptionVM()
                    .AddSideToSelectedConditionSides(_position, value);

                _selectedSide = value;
                NotifyOfPropertyChange(() => SelectedSide);
            }
        }
    }
}
