using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomElements.Panels
{
    public partial class ColorSelectionWithCountPanel : StackPanel
    {
        public ColorSelectionWithCountPanel()
        {
            InitializeComponent();
        }

        public string GetColorName()
        {
            var name = GetSelectionPanel().GetSelectedColor().Name;

            return ColorNameTranslater.ColorNames.ContainsKey(name) ? ColorNameTranslater.ColorNames[name] : name;
        }

        public Color? GetColorValue()
        {
            return GetSelectionPanel().GetSelectedColor().Color;
        }

        private ColorSelectionPanel GetSelectionPanel()
        {
            return (ColorSelectionPanel)Children[0];
        }

        private void StackPanel_Initialized(object sender, System.EventArgs e)
        {
            ColorCount.SetValueToMin();
            GetSelectionPanel().ColorPicker.AvailableColors = new ObservableCollection<ColorItem>(Application.Current.GetDefaultColors());
        }

        private void ColorCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Application.Current.UpdateDescription();
        }
    }
}
