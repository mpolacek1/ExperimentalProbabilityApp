﻿using System;
using Caliburn.Micro;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources.Calculations.General;
using ExperimentalProbability.UI.MVVM.Models.Calculations.TwoDPlane;

namespace ExperimentalProbability.UI.MVVM.ViewModels.Calculations.TwoDPlane
{
    public abstract class BaseTwoDPlaneCalculationShellViewModel : BaseCalculationShellViewModel
    {
        public BaseTwoDPlaneCalculationShellViewModel(string displayName, Screen descriptionVM, Type calcType)
            : base(displayName, descriptionVM, Resources.Results_FinalResult_Pi, typeof(TwoDPlaneCalculationResultPlaceholder), calcType)
        {
        }

        public override CalculationData GetCalculationData()
        {
            return new CalculationData(HeaderVM.Simulations.Value);
        }

        protected override string CalculateFinalResult()
        {
            return (ResultsVM.CalculateFinalResult() / ResultsVM.Results.Count).ToString();
        }
    }
}
