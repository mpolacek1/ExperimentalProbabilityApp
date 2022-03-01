using System;
using System.Text;
using ExperimentalProbability.Calculation.Models;
using LocalResx = ExperimentalProbability.Contracts.Properties.GeneralResources;

namespace ExperimentalProbability.Calculation.Validation
{
    public abstract class BaseCalculationValidator
    {
        private const int _minSimulationsToRun = 1000;

        private const int _maxSimulationsToRun = 100000000;

        public void Validate(CalculationData data)
        {
            ValidateNumber(data.SimulationsToRun, _minSimulationsToRun, _maxSimulationsToRun, LocalResx.ElementName_SimulationsToRun);
            ValidateTypeData(data);
            ValidateConditionData(data);
        }

        protected void ValidateNumber(int number, int min, int max, string elementName)
        {
            if (number < min)
            {
                ThrowValidationException(LocalResx.Error_Number_Beginning, elementName, LocalResx.Error_Number_Min, min);
            }

            if (number > max)
            {
                ThrowValidationException(LocalResx.Error_Number_Beginning, elementName, LocalResx.Error_Number_Max, max);
            }
        }

        protected abstract void ValidateTypeData(CalculationData data);

        protected abstract void ValidateConditionData(CalculationData data);

        protected void ThrowValidationException(string messBegining, string elementName, string messBetween, object value, char end = '.', char separator = ' ')
        {
            var builder = new StringBuilder(messBegining);
            builder.Append(separator);
            builder.Append(elementName);
            builder.Append(separator);
            builder.Append(messBetween);
            builder.Append(separator);
            builder.Append(value);
            builder.Append(end);

            throw new Exception(builder.ToString());
        }
    }
}
