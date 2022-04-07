using Caliburn.Micro;
using ExperimentalProbability.Contracts.Extensions;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.ColoredBalls;
using ExperimentalProbability.Contracts.Utilities;
using ExperimentalProbability.UI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;
using GeneralPoolCalcResources = ExperimentalProbability.Contracts.Properties.Resources.Calculations.Pool.General.Resources;
using GeneralResources = ExperimentalProbability.Contracts.Properties.Resources.General.Resources;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.Pool.ColoredBalls
{
    public class DescriptionViewModel : Screen
    {
        private string _poolInfo;

        private object[] _bag;

        public DescriptionViewModel()
        {
            SelectedPoolColors = new BindableCollection<string>();
            SelectedConditionColors = new BindableCollection<string>();
            Bag = new object[0];
        }

        public string CalculationInfo
            => string.Concat(GeneralPoolCalcResources.Description_CalculationInfo, ' ', Resources.CalculationInfo);

        public string PoolInfo
        {
            get
            {
                return _poolInfo;
            }

            set
            {
                _poolInfo = string.Concat(
                    ' ',
                    NumberTranslater.NumberToWord[Convert.ToInt32(value)],
                    ' ',
                    Resources.PoolItem);

                NotifyOfPropertyChange(() => PoolInfo);
            }
        }

        public BindableCollection<string> SelectedPoolColors { get; set; }

        public BindableCollection<string> SelectedConditionColors { get; set; }

        public object[] Bag
        {
            get
            {
                return _bag;
            }

            set
            {
                _bag = value;
                NotifyOfPropertyChange(() => RenderedBag);
            }
        }

        public Ellipse[] RenderedBag => RenderBag(Bag);

        public void AddColorToSelectedPoolColors(int position, int count, string color)
        {
            var fullInfo = string.Concat(
                ' ',
                NumberTranslater.NumberToWord[count],
                ' ',
                count == 1 ? Resources.BeforeColorSingular : Resources.BeforeColorPlural,
                ' ',
                color ?? GeneralResources.NotAvailable,
                '.');

            SelectedPoolColors.RewriteOrAddItem(position, fullInfo);
        }

        public void AddColorToSelectedConditionColors(int position, string color)
        {
            var fullInfo = string.Concat(
                ' ',
                NumberTranslater.NumberToPosition[position],
                ' ',
                Resources.CalcAction,
                ' ',
                color ?? GeneralResources.NotAvailable,
                '.');

            SelectedConditionColors.RewriteOrAddItem(position, fullInfo);
        }

        public void GenerateAndSetBag()
        {
            var data = GetShellVM().GetPoolData();
            var colors = (object[])data[0];
            var counts = (int[])data[1];

            var sumOfColorCounts = counts.Sum() != GetShellVM().GetPoolVM().NumberOfBalls.Value ? default : counts.Sum();
            var bag = new List<object>(sumOfColorCounts);

            if (colors.All(color => color != null))
            {
                var random = new Random();

                while (bag.Count != sumOfColorCounts)
                {
                    var index = random.Next(counts.Length);
                    var color = colors[index];

                    if (color != null && counts[index] != default)
                    {
                        counts[index]--;
                        bag.Add(color);
                    }
                }
            }

            Bag = bag.ToArray();
        }

        private Ellipse[] RenderBag(object[] bag)
        {
            var renderedBag = new List<Ellipse>(bag.Length);

            foreach (var color in bag)
            {
                renderedBag.Add(new Ellipse()
                {
                    Fill = new SolidColorBrush(ColorTranslator.CreateColorFromString(color.ToString())),
                });
            }

            return renderedBag.ToArray();
        }

        private ColoredBallsShellViewModel GetShellVM()
        {
            return (ColoredBallsShellViewModel)Parent;
        }
    }
}
