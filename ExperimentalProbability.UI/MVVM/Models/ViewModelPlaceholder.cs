using Caliburn.Micro;
using System;

namespace ExperimentalProbability.UI.MVVM.Models
{
    public class ViewModelPlaceholder : PropertyChangedBase
    {
        private bool _isShown;

        public ViewModelPlaceholder(string name, Type type = null, bool isShown = false)
        {
            Name = name;
            IsViewModelReference = type != null;
            Type = type;
            IsShown = isShown;
        }

        public string Name { get; private set; }

        public bool IsViewModelReference { get; private set; }

        public Type Type { get; private set; }

        public bool IsShown
        {
            get
            {
                return _isShown;
            }

            set
            {
                _isShown = value;
                NotifyOfPropertyChange(() => IsShown);
            }
        }
    }
}
