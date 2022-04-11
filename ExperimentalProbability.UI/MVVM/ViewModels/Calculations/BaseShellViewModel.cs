using System;
using System.ComponentModel;
using System.Windows;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Interfaces;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.UI.MVVM.Models.Calculations;
using GeneralCalcResx = ExperimentalProbability.Contracts.Properties.Resources.Calculations.General.Resources;
using GeneralResx = ExperimentalProbability.Contracts.Properties.Resources.General.Resources;
using Message = Xceed.Wpf.Toolkit.MessageBox;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations
{
    public abstract class BaseShellViewModel : Conductor<Screen>.Collection.AllActive
    {
        private const string MESSAGE_STYLE_INFO = "MessageBox_Info";

        private const string MESSAGE_STYLE_ERROR = "MessageBox_Error";

        public BaseShellViewModel(string displayName, Screen descriptionVM, string finalResultName, Type resultPlaceholderType, Type calcType)
        {
            DisplayName = displayName;

            SetUpAllViewModels(descriptionVM, finalResultName, resultPlaceholderType);

            Worker = SetUpBackgroundWorker();

            Calculation = (ICalculation)Activator.CreateInstance(calcType, Worker);
        }

        public HeaderViewModel HeaderVM { get; private set; }

        public Screen DescriptionVM { get; set; }

        public ResultsViewModel ResultsVM { get; protected set; }

        public FooterViewModel FooterVM { get; private set; }

        public BackgroundWorker Worker { get; private set; }

        public CalculationData CalculationData { get; set; }

        public ICalculation Calculation { get; set; }

        public abstract CalculationData GetCalculationData();

        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Calculation.Run(CalculationData, e);
        }

        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FooterVM.Progress = e.ProgressPercentage;
            ResultsVM.UpdateProgressResults(e.ProgressPercentage - 1, (decimal)e.UserState);
        }

        public void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ShowInfoMessage(GeneralResx.Message_Message_CalcCanceled);
            }
            else if (e.Error != null)
            {
                ShowErrorMessage(e.Error.Message);
            }
            else
            {
                Calculation.ClearResultData();
                ResultsVM.FinalResult = CalculateFinalResult();
                FooterVM.ButtonContent = GeneralCalcResx.Footer_RunCalculation;

                ShowInfoMessage(GeneralResx.Message_Message_CalcFinished);
            }
        }

        protected BindableCollection<CalculationResultPlaceholder> GenerateResults(Type resultPlaceholderType)
        {
            var results = new CalculationResultPlaceholder[(int)GeneralNumbers.MaxProgress];

            for (int i = 1; i <= results.Length; i++)
            {
                results[i - 1] = (CalculationResultPlaceholder)Activator.CreateInstance(resultPlaceholderType, i);
            }

            return new BindableCollection<CalculationResultPlaceholder>(results);
        }

        protected abstract string CalculateFinalResult();

        protected override void OnInitialize()
        {
            ActivateItem(HeaderVM);
            ActivateItem(DescriptionVM);
            ActivateItem(ResultsVM);
            ActivateItem(FooterVM);
        }

        private void SetUpAllViewModels(Screen descriptionVM, string finalResultName, Type resultPlaceholderType)
        {
            HeaderVM = new HeaderViewModel();
            DescriptionVM = descriptionVM;
            ResultsVM = new ResultsViewModel(finalResultName, GenerateResults(resultPlaceholderType));
            FooterVM = new FooterViewModel();
        }

        private BackgroundWorker SetUpBackgroundWorker()
        {
            var worker = new BackgroundWorker()
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true,
            };

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            return worker;
        }

        private void ShowInfoMessage(string message)
        {
            ShowMessage(string.Concat(DisplayName, ' ', message), GeneralResx.Message_Caption_Information, MessageBoxImage.Information, MESSAGE_STYLE_INFO);
        }

        private void ShowErrorMessage(string message)
        {
            ShowMessage(message, GeneralResx.Message_Caption_Error, MessageBoxImage.Error, MESSAGE_STYLE_ERROR);
        }

        private void ShowMessage(string message, string caption, MessageBoxImage image, string style)
        {
            Message.Show(message, caption, MessageBoxButton.OK, image, (Style)Application.Current.FindResource(style));
        }
    }
}
