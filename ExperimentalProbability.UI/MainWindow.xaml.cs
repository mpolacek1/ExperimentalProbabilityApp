using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Contracts.Properties;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Models;
using ExperimentalProbability.UI.Utilities;
using Xceed.Wpf.Toolkit;
using Message = Xceed.Wpf.Toolkit.MessageBox;

namespace ExperimentalProbability.UI
{
    public partial class MainWindow : Window
    {
        private const string _messageStyleKeyInfo = "Style_MessageBox_Info";

        private const string _messageStyleKeyError = "Style_MessageBox_Error";

        public MainWindow()
        {
            InitializeComponent();
        }

        public CalculationType CurrentType { get; set; }

        public List<ColorItem> DefaultColors => GetDefaultColors();

        public string[] Types { get; } = new string[2]
        {
            ColoredBallsResources.String_TypeName,
            DiceResources.String_TypeName,
        };

        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CurrentType.RunCalculation(e);
        }

        public void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Button_RunCalculation.Content = GeneralResources.Button_RunCalculation_Content;

            if (e.Cancelled)
            {
                ShowInfoMessage(GeneralResources.MessageBox_Message_CalculationCanceled);
            }
            else if (e.Error != null)
            {
                ShowErrorMessage(e.Error.Message);
            }
            else
            {
                View_Results.DisplayResult((CalculationResultData)e.Result);

                ShowInfoMessage(GeneralResources.MessageBox_Message_CalculationFinished);
            }
        }

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

        private void ShowInfoMessage(string message)
        {
            ShowMessage(message, GeneralResources.MessageBox_Caption_Information, MessageBoxImage.Information, _messageStyleKeyInfo);
        }

        private void ShowErrorMessage(string message)
        {
            ShowMessage(message, GeneralResources.MessageBox_Caption_Error, MessageBoxImage.Error, _messageStyleKeyError);
        }

        private void ShowMessage(string message, string caption, MessageBoxImage image, string style)
        {
            Message.Show(message, caption, MessageBoxButton.OK, image, (Style)Application.Current.FindResource(style));
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

        private void Button_RunCalculation_Click(object sender, RoutedEventArgs e)
        {
            CurrentType.SetCalculationData();
            Button_RunCalculation.Content = GeneralResources.Button_CancelCalculation_Content;

            try
            {
                CurrentType.Worker.RunWorkerAsync();
            }
            catch (InvalidOperationException)
            {
                CurrentType.Worker.CancelAsync();
            }
        }
    }
}
