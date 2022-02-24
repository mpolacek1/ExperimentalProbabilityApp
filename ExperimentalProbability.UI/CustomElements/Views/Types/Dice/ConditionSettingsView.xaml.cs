using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.CustomElements.Panels;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Properties.LocalizableResources;
using ExperimentalProbability.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.CustomElements.Views.Types.Dice
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
            var items = new List<Dictionary<string, string>>(Panel_SideSelection.Children.Count);

            if (Panel_SideSelection.Children.Count > 0)
            {
                for (int i = 0; i < Panel_SideSelection.Children.Count; i++)
                {
                    var name = GetSelectionPanel(i).GetSelectedSide();

                    items.Add(new Dictionary<string, string>(1)
                    {
                        { "count", NumberTranslater.NumberToPosition[i] },
                        { "name", name != 0 ? NumberTranslater.NumberToWord[name] : GeneralResources.String_NotAvailable },
                    });
                }
            }

            return items;
        }

        public void UpdateSelectorsItemsSources()
        {
            var itemSource = GetSelectableSides();
            var selectors = GetSelectors();

            for (int i = 0; i < selectors.Count; i++)
            {
                ((ComboBox)selectors[i]).ItemsSource = itemSource;
            }
        }

        public BasicData GetCalculationData()
        {
            return new BasicData()
            {
                NumberOf = NumberOfDiceRolls.GetValue(),
                Items = GetSelectedSides(),
            };
        }

        public List<string> GetSelectableSides()
        {
            var sides = new List<string>();

            for (int i = 1; i <= ((TypeSettingsView)Application.Current.GetCurrentCalculation().Settings).GetSidesCount(); i++)
            {
                sides.Add(NumberTranslater.NumberToWord[i]);
            }

            return sides;
        }

        public List<object> GetSelectors()
        {
            var selectors = new List<object>(Panel_SideSelection.Children.Count);

            for (int i = 0; i < Panel_SideSelection.Children.Count; i++)
            {
                selectors.Add(GetSelectionPanel(i).Children[0]);
            }

            return selectors;
        }

        private List<int> GetSelectedSides()
        {
            var sides = new List<int>(Panel_SideSelection.Children.Count);

            for (int i = 0; i < Panel_SideSelection.Children.Count; i++)
            {
                sides.Add(GetSelectionPanel(i).GetSelectedSide());
            }

            return sides;
        }

        private SideSelectionPanel GetSelectionPanel(int index)
        {
            return (SideSelectionPanel)Panel_SideSelection.Children[index];
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            NumberOfDiceRolls.SetValueToMin();
        }

        private void NumberOfDiceRolls_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Panel_SideSelection.RemoveNotNeededChildren((IntegerUpDown)sender);

            for (int i = Panel_SideSelection.Children.Count; i < ((IntegerUpDown)sender).GetValue(); i++)
            {
                Panel_SideSelection.Children.Add(new SideSelectionPanel());
            }

            Application.Current.UpdateSelectableData();
            Application.Current.UpdateDescription();
        }
    }
}
