using System;
using ExperimentalProbability.Calculation.Models;
using ExperimentalProbability.Contracts.Utilities;
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
                ThrowValidationException(elementName, LocalResx.Error_Number_Min, min);
            }

            if (number > max)
            {
                ThrowValidationException(elementName, LocalResx.Error_Number_Max, max);
            }
        }

        protected abstract void ValidateTypeData(CalculationData data);

        protected abstract void ValidateConditionData(CalculationData data);

        protected string AppendNumberPositionToString(int index, string elementName)
        {
            return $"{NumberTranslater.NumberToPosition[index]} {elementName}";
        }

        protected void ThrowValidationException(string elementName, string messBetween, object value = null, char end = '.', char separator = ' ')
        {
            var builder = TextBuilder.InitializeStringBuilder(LocalResx.Error_Beginning, separator);
            builder.Append(elementName);
            builder.Append(separator);
            builder.Append(messBetween);

            if (!value.Equals(null))
            {
                builder.Append(separator);
                builder.Append(value);
            }

            builder.Append(end);

            throw new Exception(builder.ToString());
        }
    }
}
