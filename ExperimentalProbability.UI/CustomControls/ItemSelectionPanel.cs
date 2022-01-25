using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExperimentalProbability.UI.CustomControls
{
    public class ItemSelectionPanel : DockPanel
    {
        public ItemSelectionPanel(MainWindow window, string text, string[] itemsSource)
        {
            DefaultElementSettings();
            Children.Add(BuildItemSelector(window, text, itemsSource));
        }

        public ItemSelectionPanel(MainWindow window)
        {
            DefaultElementSettings();
            Children.Add(BuildColorSelector(window));
            Children.Add(BuildColorText(window));
            Children.Add(BuildNumberOfColors(window));
        }

        private void DefaultElementSettings()
        {
            LastChildFill = false;
            Margin = new Thickness(0, 0, 5, 0);
        }

        private ComboBox BuildItemSelector(MainWindow window, string text, string[] itemsSource)
        {
            var selector = GetItemSelector(text, itemsSource);

            return selector;
        }

        private ComboBox BuildColorSelector(MainWindow window)
        {
            var selector = GetItemSelector(Properties.Resources.Default_Selection_ColoredBalls, window.Colors);

            selector.SelectionChanged += new SelectionChangedEventHandler(window.Selection_ColoredBalls_Color_SelectionChanged);

            SetDock(selector, Dock.Top);

            return selector;
        }

        private ComboBox GetItemSelector(string text, string[] itemsSource)
        {
            return new ComboBox()
            {
                Margin = new Thickness(0, 0, 0, 5),
                IsEditable = true,
                IsReadOnly = true,
                Text = text,
                ItemsSource = itemsSource,
            };
        }

        private static TextBlock BuildColorText(MainWindow window)
        {
            return new TextBlock()
            {
                Margin = new Thickness(0, 0, 5, 0),
                Text = Properties.Resources.Text_ColoredBalls_ColorNumber,
            };
        }

        private static TextBox BuildNumberOfColors(MainWindow window)
        {
            var textBox = new TextBox()
            {
                Width = 30,
                TextAlignment = TextAlignment.Right,
                MaxLength = 2,
                MaxLines = 1,
                Text = Properties.Resources.Default_ColoredBalls_ColorNumber,
            };

            SetDock(textBox, Dock.Right);

            return textBox;
        }
    }
}
