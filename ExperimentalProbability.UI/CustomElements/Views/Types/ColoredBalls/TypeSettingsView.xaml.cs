using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.CustomElements.Panels;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Properties.LocalizableResources;
using ExperimentalProbability.UI.Utilities;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls
{
    public partial class TypeSettingsView : UserControl, ITypeSettings
    {
        public TypeSettingsView()
        {
            InitializeComponent();
        }

        public List<Color> CurrentPool { get; set; }

        public DescriptionData GetDescriptionData()
        {
            var count = NumberOfBalls.GetValue();

            return new DescriptionData(count != 0 ? NumberTranslater.NumberToWord[count] : GeneralResources.String_NotAvailable, GetDescriptionItems());
        }

        public List<ColorPicker> GetSelectors()
        {
            var selectors = new List<ColorPicker>(Panel_ColorSelection.Children.Count);

            for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
            {
                selectors.Add(((ColorSelectionPanel)GetSelectionPanel(i).Children[0]).ColorPicker);
            }

            return selectors;
        }

        public void UpdateAvailableColors()
        {
            var selectors = GetSelectors();
            var selectedColors = GetSelectedColors();

            for (int i = 0; i < selectors.Count; i++)
            {
                var availableColors = Application.Current.GetDefaultColors();
                var selectedColor = selectors[i].SelectedColor;

                for (int j = 0; j < selectedColors.Count; j++)
                {
                    var currentColor = selectedColors[j].Color;

                    if (currentColor.HasValue
                        && (!selectedColor.HasValue
                            || (selectedColor.HasValue
                                && !currentColor.Value.Equals(selectedColor.Value))))
                    {
                        availableColors.Remove(selectedColors[j]);
                    }
                }

                selectors[i].AvailableColors = new ObservableCollection<ColorItem>(availableColors);
            }
        }

        public List<ColorItem> GetSelectedColors()
        {
            var colors = new List<ColorItem>(Panel_ColorSelection.Children.Count);

            for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
            {
                var color = GetColorValue(i);

                if (color.HasValue)
                {
                    colors.Add(new ColorItem(color, GetColorName(i)));
                }
            }

            return colors;
        }

        /*public List<Color> GeneratePool()
        {
            var colors = GetSelectedColors();
            var counts = GetColorCounts();

            for (int i = 0; i < colors.Count; i++)
            {
                if (!colors[i].Color.HasValue || counts[i].GetValue() > 0)
                {
                    colors.RemoveAt(i);
                    counts.RemoveAt(i);
                }
            }

            var pool = new List<Color>(NumberOfBalls.GetValue());

            if (NumberOfBalls.Validate() && NumberOfColors.Validate() && colors.Count > 0)
            {
                var random = new Random();

                for (int i = 0; i < pool.Capacity; i++)
                {
                    var num = random.Next(0, colors.Count);
                    if (counts[num].GetValue() > 0)
                    {
                        pool.Insert(i, colors[num].Color.Value);
                        counts[num].Value -= 1;
                    }
                }
            }

            return pool;
        }*/

        private List<Dictionary<string, string>> GetDescriptionItems()
        {
            var items = new List<Dictionary<string, string>>(Panel_ColorSelection.Children.Count);

            if (Panel_ColorSelection.Children.Count > 0)
            {
                for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
                {
                    var count = GetColorCount(i).GetValue();
                    var name = GetColorName(i);

                    items.Add(new Dictionary<string, string>(1)
                    {
                        { "count", count != 0 ? NumberTranslater.NumberToWord[count] : GeneralResources.String_NotAvailable },
                        { "name", name != string.Empty ? name : GeneralResources.String_NotAvailable },
                    });
                }
            }

            return items;
        }

        private IntegerUpDown GetColorCount(int index)
        {
            return GetSelectionPanel(index).ColorCount;
        }

        private string GetColorName(int index)
        {
            return GetSelectionPanel(index).GetColorName();
        }

        private Color? GetColorValue(int index)
        {
            return GetSelectionPanel(index).GetColorValue();
        }

        private ColorSelectionWithCountPanel GetSelectionPanel(int index)
        {
            return (ColorSelectionWithCountPanel)Panel_ColorSelection.Children[index];
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            NumberOfBalls.SetValueToMin();
            NumberOfColors.SetValueToMin();
        }

        private void NumberOfBalls_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UpdateColorCountsMaxValue((IntegerUpDown)sender);

            Application.Current.UpdateDescription();
        }

        private void NumberOfColors_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Panel_ColorSelection.RemoveNotNeededChildren((IntegerUpDown)sender);

            for (int i = Panel_ColorSelection.Children.Count; i < ((IntegerUpDown)sender).GetValue(); i++)
            {
                Panel_ColorSelection.Children.Add(new ColorSelectionWithCountPanel());
            }

            UpdateColorCountsMaxValue(NumberOfBalls);

            Application.Current.UpdateSelectableData();

            Application.Current.UpdateDescription();
        }

        private void UpdateColorCountsMaxValue(IntegerUpDown numberOfBalls)
        {
            if (Panel_ColorSelection.Children.Count > 0)
            {
                GetColorCounts().ForEach(x => x.Maximum = numberOfBalls.GetValue() > 0 ? numberOfBalls.GetValue() - Panel_ColorSelection.Children.Count + 1 : 1);
            }
        }

        private List<IntegerUpDown> GetColorCounts()
        {
            var result = new List<IntegerUpDown>(Panel_ColorSelection.Children.Count);

            for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
            {
                result.Add(GetColorCount(i));
            }

            return result;
        }

        public BasicData GetCalculationData()
        {
            throw new NotImplementedException();
        }
    }
}
