using Caliburn.Micro;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.MVVM.Views.Calculations.Pool.ColoredBalls;
using ExperimentalProbability.UI.Utilities;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class ColorPickerViewModel : Screen
    {
        private Color? _color;

        private string _colorName;

        public ColorPickerViewModel(int position, ColorItem[] availableColors)
        {
            Position = position;
            AvailableColors = new BindableCollection<ColorItem>(availableColors);
        }

        public int Position { get; private set; }

        public BindableCollection<ColorItem> AvailableColors { get; set; }

        public Color? SelectedColor
        {
            get
            {
                return _color;
            }

            set
            {
                if (value.HasValue)
                {
                    ColorItem previousSelectedColor = null;

                    if (_color.HasValue)
                    {
                        previousSelectedColor = new ColorItem(_color, SelectedColorName);
                    }

                    SelectedColorName = ColorTranslator.ColorNames[value.ToString()];

                    TryUpdateAvailableAndSelectableColors(previousSelectedColor, new ColorItem(value, SelectedColorName));
                }

                ((ColorPickerView)GetView()).ColorPickerLabel.HideOrShow(value);

                _color = value;

                if (IsParentColorPickerWithCountVM() && _color.HasValue)
                {
                    GetDescriptionVMFromPoolVM().GenerateAndSetBag();
                }

                NotifyOfPropertyChange(() => SelectedColor);
            }
        }

        public string SelectedColorName
        {
            get
            {
                return _colorName;
            }

            set
            {
                _colorName = value;

                if (IsParentColorPickerWithCountVM())
                {
                    GetDescriptionVMFromPoolVM().AddColorToSelectedPoolColors(Position, GetColorPickerWithCountVM().Count.Value, value);
                }
                else
                {
                    GetDescriptionVMFromConditionVM().AddColorToSelectedConditionColors(Position, value);
                }

                NotifyOfPropertyChange(() => SelectedColorName);
            }
        }

        private void TryUpdateAvailableAndSelectableColors(ColorItem previousSelectedColor, ColorItem currentSelectedColor)
        {
            if (IsParentColorPickerWithCountVM())
            {
                GetColorPickerWithCountVM().UpdateAvailableColors(previousSelectedColor, currentSelectedColor);
                GetConditionVMFromPoolVM().UpdateSelectableColors(Position, currentSelectedColor);
            }
        }

        private bool IsParentColorPickerWithCountVM()
        {
            return Parent.GetType() == typeof(ColorPickerWithCountViewModel);
        }

        private ColorPickerWithCountViewModel GetColorPickerWithCountVM()
        {
            return (ColorPickerWithCountViewModel)Parent;
        }

        private ConditionViewModel GetConditionVMFromPoolVM()
        {
            return GetColorPickerWithCountVM().GetPoolVM().GetShellVM().GetConditionVM();
        }

        private DescriptionViewModel GetDescriptionVMFromPoolVM()
        {
            return GetColorPickerWithCountVM().GetPoolVM().GetDescriptionVM();
        }

        private DescriptionViewModel GetDescriptionVMFromConditionVM()
        {
            return ((ConditionViewModel)Parent).GetDescriptionVM();
        }
    }
}
