using System.ComponentModel;
using System.Windows;
using ExperimentalProbability.Calculation.Calculations;
using ExperimentalProbability.Calculation.Interfaces;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.UI.Extensions;
using ExperimentalProbability.UI.Interfaces;
using ColoredBallsCondition = ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls.ConditionSettingsView;
using ColoredBallsDescription = ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls.DescriptionView;
using ColoredBallsSettings = ExperimentalProbability.UI.CustomElements.Views.Types.ColoredBalls.TypeSettingsView;
using DiceCondition = ExperimentalProbability.UI.CustomElements.Views.Types.Dice.ConditionSettingsView;
using DiceDescription = ExperimentalProbability.UI.CustomElements.Views.Types.Dice.DescriptionView;
using DiceSettings = ExperimentalProbability.UI.CustomElements.Views.Types.Dice.TypeSettingsView;

namespace ExperimentalProbability.UI.Models
{
    public class CalculationType
    {
        public CalculationType(MainWindow window, int index)
        {
            Settings = (ITypeSettings)window.Panel_TypeSettings.Children[index];
            Condition = (ITypeCondition)window.Panel_TypeConditions.Children[index];
            Description = (ITypeDescription)window.Panel_TypeDescriptions.Children[index];

            Worker = new BackgroundWorker();
            Worker.DoWork += window.Worker_DoWork;
            Worker.RunWorkerCompleted += window.Worker_RunWorkerCompleted;
            Worker.WorkerSupportsCancellation = true;
        }

        public ITypeSettings Settings { get; private set; }

        public ITypeCondition Condition { get; private set; }

        public ITypeDescription Description { get; private set; }

        public BackgroundWorker Worker { get; private set; }

        private ICalculationType Calculation { get; set; }

        private CalculationData Data { get; set; }

        public void UpdateDescription()
        {
            Description.UpdateDescription(Settings.GetDescriptionData(), Condition.GetDescriptionData());
        }

        public void UpdateSelectableData()
        {
            Condition.UpdateSelectorsItemsSources();
        }

        public void SetCalculationData()
        {
            Data = new CalculationData(
                Settings.GetCalculationData(),
                Condition.GetCalculationData(),
                Application.Current.GetMainWindow().IntegerUpDown_SimulationsToRun.GetValue());
        }

        public CalculationResultData RunCalculation(DoWorkEventArgs e)
        {
            if (IsCalculationOfTypeColoredBalls())
            {
                Calculation = new ColoredBallsCalculation(Data, Worker);
            }

            if (IsCalculationOfTypeDice())
            {
                Calculation = new DiceCalculation(Data, Worker);
            }

            return Calculation.Calculate(e);
        }

        public bool IsCalculationOfTypeColoredBalls()
        {
            return Settings.GetType() == typeof(ColoredBallsSettings)
                && Condition.GetType() == typeof(ColoredBallsCondition)
                && Description.GetType() == typeof(ColoredBallsDescription);
        }

        public bool IsCalculationOfTypeDice()
        {
            return Settings.GetType() == typeof(DiceSettings)
                && Condition.GetType() == typeof(DiceCondition)
                && Description.GetType() == typeof(DiceDescription);
        }
    }
}
