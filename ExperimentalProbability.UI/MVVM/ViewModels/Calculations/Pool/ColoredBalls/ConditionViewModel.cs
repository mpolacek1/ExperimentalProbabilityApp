using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Extensions;
using System.Collections.Generic;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class ConditionViewModel : Conductor<ColorPickerViewModel>.Collection.AllActive
    {
        private int? _numberOfTakenBalls;

        private int _maxNumberOfTakenBalls;

        public ConditionViewModel()
        {
            SelectableColors = new List<ColorItem>();
        }

        public int? NumberOfTakenBalls
        {
            get
            {
                return _numberOfTakenBalls;
            }

            set
            {
                _numberOfTakenBalls = value;
                UpdateColorSelection(value.Value);

                NotifyOfPropertyChange(() => NumberOfTakenBalls);
            }
        }

        public int MinNumberOfTakenBalls => (int)ColoredBallsNumbers.MinNumberOfTakenBalls;

        public int MaxNumberOfTakenBalls
        {
            get
            {
                return _maxNumberOfTakenBalls;
            }

            set
            {
                _maxNumberOfTakenBalls = value.GetMaxValueIfExceeded((int)ColoredBallsNumbers.MaxNumberOfTakenBalls);

                NotifyOfPropertyChange(() => MaxNumberOfTakenBalls);
                NotifyOfPropertyChange(() => MaxNumberOfTakenBallsLength);
            }
        }

        public int MaxNumberOfTakenBallsLength => MaxNumberOfTakenBalls.Length();

        public List<ColorItem> SelectableColors { get; set; }

        public void UpdateSelectableColors(int position, ColorItem color)
        {
            SelectableColors.RewriteOrAddItem(position, color);

            Items.Apply(item => item.AvailableColors.RewriteOrAddItem(position, color));
        }

        public void RemoveColorFromSelectableColorsByIndex(int index)
        {
            var selectableColorsLastIndex = SelectableColors.Count - 1;

            if (selectableColorsLastIndex < index)
            {
                index = selectableColorsLastIndex;
            }

            if (index >= 0)
            {
                SelectableColors.RemoveAt(index);

                Items.Apply(item => item.AvailableColors.RemoveAt(index));
            }
        }

        public DescriptionViewModel GetDescriptionVM()
        {
            return ((ColoredBallsShellViewModel)Parent).GetDescriptionVM();
        }

        protected override void OnInitialize()
        {
            NumberOfTakenBalls = (int)ColoredBallsNumbers.MinNumberOfTakenBalls;
        }

        private void UpdateColorSelection(int numberOfTakenBalls)
        {
            if (numberOfTakenBalls < Items.Count)
            {
                for (int i = Items.Count - 1; i >= numberOfTakenBalls; i--)
                {
                    GetDescriptionVM().SelectedConditionColors.RemoveAt(i);
                    Items.RemoveAt(i);
                }
            }
            else if (numberOfTakenBalls > Items.Count)
            {
                for (int i = Items.Count; i < numberOfTakenBalls; i++)
                {
                    ActivateItem(new ColorPickerViewModel(i, SelectableColors.ToArray()));
                    GetDescriptionVM().AddColorToSelectedConditionColors(i, Items[i].SelectedColorName);
                }
            }
        }
    }
}
