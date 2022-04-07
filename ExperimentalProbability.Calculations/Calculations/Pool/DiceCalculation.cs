using ExperimentalProbability.Calculations.CalculationDataValidation.Pool;
using ExperimentalProbability.Contracts.Enums;
using ExperimentalProbability.Contracts.Models;
using ExperimentalProbability.Contracts.Models.Pool;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExperimentalProbability.Calculations.Calculations.Pool
{
    public class DiceCalculation : BasePoolCalculation
    {
        public DiceCalculation(BackgroundWorker worker)
            : base(new DiceDataValidator(), worker)
        {
        }

        protected override bool CheckCondition(CalculationData data, object simResult)
        {
            var calcData = (DiceCalculationData)data;
            var rolls = (int[])simResult;

            for (int i = default; i < rolls.Length; i++)
            {
                if (rolls[i] != calcData.ConditionSides[i])
                {
                    return false;
                }
            }

            return true;
        }

        protected override object GetSimulationResult(CalculationData data, Random random)
        {
            var calcData = (DiceCalculationData)data;
            var numberOfRolls = calcData.ConditionSides.Length;
            var rolls = new List<int>(numberOfRolls);

            for (int i = default; i < numberOfRolls; i++)
            {
                rolls.Add(random.Next((int)DiceNumbers.MinRollResult, calcData.SideCount + 1));
            }

            return rolls.ToArray();
        }
    }
}
