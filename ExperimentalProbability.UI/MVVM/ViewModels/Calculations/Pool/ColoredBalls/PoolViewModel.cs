using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Extensions;
using ExperimentalProbability.UI.Utilities;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class PoolViewModel : Conductor<ColorPickerWithCountViewModel>.Collection.AllActive
    {
        private int? _numberOfBalls;

        private int _maxNumberOfColors;

        private int? _numberOfColors;

        public PoolViewModel()
        {
            _maxNumberOfColors = (int)ColoredBallsNumbers.MinNumberOfBalls;
        }

        public List<ColorItem> AvailableColors { get; set; }

        public int? NumberOfBalls
        {
            get
            {
                return _numberOfBalls;
            }

            set
            {
                _numberOfBalls = value;
                MaxNumberOfColors = value.Value;
                UpdateColorCountMaximums(value.Value - 1);
                GetConditionVM().MaxNumberOfTakenBalls = value.Value;
                GetDescriptionVM().PoolInfo = value.Value.ToString();

                NotifyOfPropertyChange(() => NumberOfBalls);
            }
        }

        public int MinNumberOfBalls => (int)ColoredBallsNumbers.MinNumberOfBalls;

        public int MaxNumberOfBalls => (int)ColoredBallsNumbers.MaxNumberOfBalls;

        public int MaxNumberOfBallsLength => MaxNumberOfBalls.Length();

        public int? NumberOfColors
        {
            get
            {
                return _numberOfColors;
            }

            set
            {
                _numberOfColors = value;
                UpdateColorSelection(value.Value, NumberOfBalls.Value - 1);

                NotifyOfPropertyChange(() => NumberOfColors);
            }
        }

        public int MinNumberOfColors => (int)ColoredBallsNumbers.MinNumberOfColors;

        public int MaxNumberOfColors
        {
            get
            {
                return _maxNumberOfColors;
            }

            set
            {
                _maxNumberOfColors = value.GetMaxValueIfExceeded((int)ColoredBallsNumbers.MaxNumberOfColors);

                NotifyOfPropertyChange(() => MaxNumberOfColors);
                NotifyOfPropertyChange(() => MaxNumberOfColorsLength);
            }
        }

        public int MaxNumberOfColorsLength => MaxNumberOfColors.Length();

        public void UpdateColorCountMaximums(int max)
        {
            foreach (var item in Items)
            {
                item.MaxCount = max;
            }
        }

        public ColoredBallsShellViewModel GetShellVM()
        {
            return (ColoredBallsShellViewModel)Parent;
        }

        public DescriptionViewModel GetDescriptionVM()
        {
            return GetShellVM().GetDescriptionVM();
        }

        protected override void OnInitialize()
        {
            AvailableColors = new List<ColorItem>(ColorTranslator.GenerateDefaultAvailableColors());
            NumberOfBalls = (int)ColoredBallsNumbers.MinNumberOfBalls;
            NumberOfColors = (int)ColoredBallsNumbers.MinNumberOfColors;
        }

        private void UpdateColorSelection(int numberOfColors, int maxCount)
        {
            if (numberOfColors < Items.Count)
            {
                for (int i = Items.Count - 1; i >= numberOfColors; i--)
                {
                    GetConditionVM().RemoveColorFromSelectableColorsByIndex(i);
                    GetDescriptionVM().SelectedPoolColors.RemoveAt(i);
                    Items.RemoveAt(i);
                }
            }
            else if (numberOfColors > Items.Count)
            {
                for (int i = Items.Count; i < numberOfColors; i++)
                {
                    ActivateItem(new ColorPickerWithCountViewModel(maxCount, i, AvailableColors.ToArray()));
                    GetDescriptionVM().AddColorToSelectedPoolColors(i, Items[i].Count.Value, Items[i].ActiveItem.SelectedColorName);
                }
            }
        }

        private ConditionViewModel GetConditionVM()
        {
            return GetShellVM().GetConditionVM();
        }
    }
}
