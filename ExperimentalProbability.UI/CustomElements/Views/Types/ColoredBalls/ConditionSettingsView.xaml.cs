using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Contracts.Properties;
using ExperimentalProbability.Contracts.Utilities;
using ExperimentalProbability.UI.CustomElements.Panels;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls
{
    public partial class ConditionSettingsView : UserControl, ITypeCondition
    {
        public ConditionSettingsView()
        {
            InitializeComponent();
        }

        public DescriptionData GetDescriptionData()
        {
            return new DescriptionData(string.Empty, GetDescriptionItems());
        }

        public List<Dictionary<string, string>> GetDescriptionItems()
        {
            var items = new List<Dictionary<string, string>>(Panel_ColorSelection.Children.Count);

            if (Panel_ColorSelection.Children.Count > 0)
            {
                for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
                {
                    var name = GetSelectionPanel(i).GetSelectedColor().Name;

                    items.Add(new Dictionary<string, string>(1)
                    {
                        { "count", NumberTranslater.NumberToPosition[i] },
                        { "name",  name != string.Empty ? name : GeneralResources.String_NotAvailable },
                    });
                }
            }

            return items;
        }

        public void UpdateSelectorsItemsSources()
        {
            ((TypeSettingsView)Application.Current.GetCurrentSettings()).UpdateAvailableColors();
            UpdateAvailableColors();
        }

        public BasicData GetCalculationData()
        {
            return new BasicData(NumberOfTakenBalls.GetValue(), GetCalculationDataItems());
        }

        private List<Color?> GetCalculationDataItems()
        {
            var items = new List<Color?>(NumberOfTakenBalls.GetValue());

            for (int i = 0; i < NumberOfTakenBalls.GetValue(); i++)
            {
                items.Add(GetSelectionPanel(i).GetSelectedColor().Color);
            }

            return items;
        }

        private void UpdateAvailableColors()
        {
            var selectors = GetSelectors();
            var selectableColors = ((TypeSettingsView)Application.Current.GetCurrentSettings()).GetSelectedColors();

            for (int i = 0; i < selectors.Count; i++)
            {
                selectors[i].AvailableColors = new ObservableCollection<ColorItem>(selectableColors);
            }
        }

        private List<ColorPicker> GetSelectors()
        {
            var selectors = new List<ColorPicker>(Panel_ColorSelection.Children.Count);

            for (int i = 0; i < Panel_ColorSelection.Children.Count; i++)
            {
                selectors.Add(GetSelectionPanel(i).ColorPicker);
            }

            return selectors;
        }

        private ColorSelectionPanel GetSelectionPanel(int index)
        {
            return (ColorSelectionPanel)Panel_ColorSelection.Children[index];
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            NumberOfTakenBalls.SetValueToMin();
        }

        private void NumberOfTakenBalls_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Panel_ColorSelection.RemoveNotNeededChildren((IntegerUpDown)sender);

            for (int i = Panel_ColorSelection.Children.Count; i < ((IntegerUpDown)sender).GetValue(); i++)
            {
                Panel_ColorSelection.Children.Add(new ColorSelectionPanel());
            }

            Application.Current.UpdateSelectableData();

            Application.Current.UpdateDescription();
        }
    }
}
