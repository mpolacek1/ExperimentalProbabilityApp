using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Properties.LocalizableResources;
using ExperimentalProbability.UI.Utilities;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        private readonly BackgroundWorker _worker;

        public MainWindow()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public CalculationType CurrentType { get; set; }

        public List<ColorItem> DefaultColors => GetDefaultColors();

        public string[] Types { get; } = new string[2]
        {
            ColoredBallsResources.String_TypeName,
            DiceResources.String_TypeName,
        };

        private static List<ColorItem> GetDefaultColors()
        {
            var defaultColors = new ColorPicker().AvailableColors;
            var newColors = new List<ColorItem>();

            for (int i = 0; i < defaultColors.Count; i++)
            {
                newColors.Add(new ColorItem(defaultColors[i].Color.Value, ColorNameTranslater.ColorNames[defaultColors[i].Name]));
            }

            return newColors;
        }

        private void ComboBox_TypeSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Panel_Settings.ChangeVisibility(Visibility.Visible);
            View_Tutorial.ChangeVisibility(Visibility.Collapsed);
            Panel_Descriptions.ChangeVisibility(Visibility.Visible);
            Button_RunCalculation.IsEnabled = true;

            var selector = (ComboBox)sender;

            CurrentType = new CalculationType(this, selector.SelectedIndex);

            CurrentType.UpdateSelectableData();
            CurrentType.UpdateDescription();
            UpdateVisibilityOfTypeViews(selector);
        }

        private void UpdateVisibilityOfTypeViews(ComboBox selector)
        {
            for (int i = 0; i < selector.Items.Count; i++)
            {
                if (i == selector.SelectedIndex)
                {
                    ChangeVisibilityOfTypeViews(i, Visibility.Visible);
                }
                else
                {
                    ChangeVisibilityOfTypeViews(i, Visibility.Collapsed);
                }
            }
        }

        private void ChangeVisibilityOfTypeViews(int index, Visibility visibility)
        {
            Panel_TypeSettings.ChangeVisibilityOfChild(index, visibility);
            Panel_TypeConditions.ChangeVisibilityOfChild(index, visibility);
            Panel_TypeDescriptions.ChangeVisibilityOfChild(index, visibility);
        }

        private void Button_RunCalculation_Click(object sender, RoutedEventArgs e)
        {
            CurrentType.SetCalculationData();
            _worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CurrentType.RunCalculation();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                View_Results.DisplayResult((CalculationResultData)e.Result);
            }
        }
    }
}
