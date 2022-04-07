using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Extensions;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class ColorPickerWithCountViewModel : Conductor<ColorPickerViewModel>
    {
        private int _maxCount;

        private int? _count;

        public ColorPickerWithCountViewModel(int maxCount, int position, ColorItem[] availableColors)
        {
            _count = (int)ColoredBallsNumbers.MinColorCount;
            MaxCount = maxCount;

            ActivateItem(new ColorPickerViewModel(position, availableColors));
        }

        public int? Count
        {
            get
            {
                return _count;
            }

            set
            {
                GetDescriptionVM().AddColorToSelectedPoolColors(ActiveItem.Position, value.Value, ActiveItem.SelectedColorName);

                _count = value;

                GetDescriptionVM().GenerateAndSetBag();

                NotifyOfPropertyChange(() => Count);
            }
        }

        public int MinCount => (int)ColoredBallsNumbers.MinColorCount;

        public int MaxCount
        {
            get
            {
                return _maxCount;
            }

            set
            {
                _maxCount = value;
                NotifyOfPropertyChange(() => MaxCount);
                NotifyOfPropertyChange(() => MaxCountLength);
            }
        }

        public int MaxCountLength => MaxCount.Length();

        public void UpdateAvailableColors(ColorItem previousColor, ColorItem currentColor)
        {
            var poolVM = GetPoolVM();

            poolVM.AvailableColors.TryAddAndRemove(previousColor, currentColor);

            foreach (var item in poolVM.Items)
            {
                if (item != this)
                {
                    item.ActiveItem.AvailableColors.TryAddAndRemove(previousColor, currentColor);
                }
                else
                {
                    if (previousColor != null)
                    {
                        item.ActiveItem.AvailableColors.Add(previousColor);
                    }
                }
            }
        }

        public PoolViewModel GetPoolVM()
        {
            return (PoolViewModel)Parent;
        }

        private DescriptionViewModel GetDescriptionVM()
        {
            return GetPoolVM().GetDescriptionVM();
        }
    }
}
