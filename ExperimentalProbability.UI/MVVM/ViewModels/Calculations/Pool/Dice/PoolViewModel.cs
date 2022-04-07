using System.Collections.Generic;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.Dice;
using ExperimentalProbability.Contracts.Utilities;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.Dice
{
    public class PoolViewModel : Screen
    {
        private readonly Dictionary<string, int> _diceTypes;

        private string _selectedDiceType;

        public PoolViewModel()
        {
            _diceTypes = new Dictionary<string, int>()
            {
                { Resources.Dice_Tetrahedron, (int)DiceNumbers.SideCountTetrahedron },
                { Resources.Dice_Cube, (int)DiceNumbers.SideCountCube },
                { Resources.Dice_Octahedron, (int)DiceNumbers.SideCountOctahedron },
                { Resources.Dice_PentagonalTrapezohedron, (int)DiceNumbers.SideCountPentagonalTrapezohedron },
                { Resources.Dice_Dodecahedron, (int)DiceNumbers.SideCountDodecahedron },
                { Resources.Dice_Icosahedron, (int)DiceNumbers.SideCountIcosahedron },
            };
        }

        public Dictionary<string, int> DiceTypes => _diceTypes;

        public string SelectedDiceType
        {
            get
            {
                return _selectedDiceType;
            }

            set
            {
                _selectedDiceType = value;
                GetShellVM().GetConditionVM().SelectableSides = GenerateSelectableSides(value);
                GetShellVM().GetDescriptionVM().PoolInfo = value;
                NotifyOfPropertyChange(() => SelectedDiceType);
            }
        }

        private string[] GenerateSelectableSides(string diceType)
        {
            var numberOfSides = DiceTypes[diceType];

            var selectableSides = new string[numberOfSides];

            for (int i = 1; i <= numberOfSides; i++)
            {
                selectableSides[i - 1] = NumberTranslater.NumberToWord[i];
            }

            return selectableSides;
        }

        private DiceShellViewModel GetShellVM()
        {
            return (DiceShellViewModel)Parent;
        }
    }
}
