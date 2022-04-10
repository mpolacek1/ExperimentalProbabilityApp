using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Exceptions;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources.Validation;
using GeneralCalcResources = ExperimentalProbability.Contracts.Properties.Resources.Calculations.General.Resources;

namespace ExperimentalProbability.Calculations.CalculationDataValidation
{
    public class CalculationDataValidator
    {
        public virtual void Validate(CalculationData data)
        {
            ValidateNumber(data.SimulationsToRun, (int)GeneralNumbers.MinSimulations, (int)GeneralNumbers.MaxSimulations, GeneralCalcResources.ElementName_SimulationsToRun);
        }

        protected void ValidateNumber(int number, int min, int max, string elementName)
        {
            if (number < min)
            {
                throw new ValidationException(elementName, Resources.Error_Number_Min, min);
            }

            if (number > max)
            {
                throw new ValidationException(elementName, Resources.Error_Number_Max, max);
            }
        }
    }
}
