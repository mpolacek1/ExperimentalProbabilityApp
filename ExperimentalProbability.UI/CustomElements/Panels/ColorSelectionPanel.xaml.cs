using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.Contracts.Properties;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomElements.Panels
{
    public partial class ColorSelectionPanel : WrapPanel
    {
        public ColorSelectionPanel()
        {
            InitializeComponent();
        }

        public ColorItem GetSelectedColor()
        {
            return new ColorItem(ColorPicker.SelectedColor, ColorPicker.SelectedColorText);
        }

        private void WrapPanel_Initialized(object sender, EventArgs e)
        {
            ColorPicker.AvailableColors = new ObservableCollection<ColorItem>();
            ColorPicker.AvailableColorsHeader = ColoredBallsResources.ColorPicker_NoAvailableColorsHeader;
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Children[0].Visibility = Visibility.Collapsed;

            ((ColorPicker)sender).IsOpen = false;

            Application.Current.UpdateSelectableData();

            Application.Current.UpdateDescription();
        }

        private void ColorPicker_Opened(object sender, RoutedEventArgs e)
        {
            var selector = (ColorPicker)sender;

            if (selector.AvailableColors.Count == 0)
            {
                selector.AvailableColorsHeader = ColoredBallsResources.ColorPicker_NoAvailableColorsHeader;
            }
            else
            {
                selector.AvailableColorsHeader = ColoredBallsResources.ColorPicker_AvailableColorsHeader;
            }
        }
    }
}
