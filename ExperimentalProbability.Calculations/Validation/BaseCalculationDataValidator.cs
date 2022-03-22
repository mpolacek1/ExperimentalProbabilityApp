using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Properties.Resources.Validation.BaseCalculationData;
using ExperimentalProbability.Contracts.Utilities;
using System;

namespace ExperimentalProbability.Calculations.Validation
{
    public abstract class BaseCalculationDataValidator
    {
        public abstract void Validate(CalculationData data);

        protected void ValidateNumber(int number, int min, int max, string elementName)
        {
            if (number < min)
            {
                ThrowValidationException(elementName, Resources.Error_Number_Min, min);
            }

            if (number > max)
            {
                ThrowValidationException(elementName, Resources.Error_Number_Max, max);
            }
        }

        protected string AppendNumberPositionToString(int index, string elementName)
        {
            return string.Concat(NumberTranslater.NumberToPosition[index], ' ', elementName);
        }

        protected void ThrowValidationException(string elementName, string messBetween, object value = null, char end = '.', char separator = ' ')
        {
            var message = string.Concat(Resources.Error_Beginning, separator, elementName, separator, messBetween);

            if (!value.Equals(null))
            {
                message = string.Concat(message, separator, value);
            }

            message = string.Concat(message, end);

            throw new Exception(message);
        }
    }
}
