using Caliburn.Micro;
using ExperimentalProbability.UI.MVVM.ViewModels;
using System;

namespace ExperimentalProbability.UI.MVVM.Models
{
    public class ViewModelPlaceholder : PropertyChangedBase
    {
        private bool _isShown;

        public ViewModelPlaceholder(string name, bool isVMReference = false, Type type = null, bool isShown = false)
        {
            Name = name;
            IsViewModelReference = isVMReference;
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
