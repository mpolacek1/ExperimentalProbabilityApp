using ExperimentalProbability.UI.Interfaces;
using ExperimentalProbability.UI.Models;
using System.Collections.Generic;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Extensions
{
    public static class ApplicationExtensions
    {
        public static MainWindow GetMainWindow(this Application app)
        {
            return (MainWindow)app.MainWindow;
        }

        public static List<ColorItem> GetDefaultColors(this Application app)
        {
            return app.GetMainWindow().DefaultColors;
        }

        public static CalculationType GetCurrentCalculation(this Application app)
        {
            return app.GetMainWindow().CurrentType;
        }

        public static void UpdateDescription(this Application app)
        {
            var type = app.GetCurrentCalculation();

            if (type != null)
            {
                type.UpdateDescription();
            }
        }

        public static void UpdateSelectableData(this Application app)
        {
            var type = app.GetCurrentCalculation();

            if (type != null)
            {
                type.UpdateSelectableData();
            }
        }

        public static ITypeSettings GetCurrentSettings(this Application app)
        {
            return app.GetCurrentCalculation().Settings;
        }
    }
}
