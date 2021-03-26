using Resistor.Models;
using System;
using Resistor.Utility;

namespace Resistor
{
    public class CalculateOhmValues : ICalculateOhmValues
    {
        private readonly ResistorBands _resistorBands;

        public CalculateOhmValues()
        {
            _resistorBands = new ResistorBands();
        }

        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>resistance in ohms</returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int value = Convert.ToInt32(string.Format("{0}{1}", _resistorBands.BandAAndB[bandAColor], _resistorBands.BandAAndB[bandBColor]));
            int multiplier = _resistorBands.Multiplier[bandCColor];

            return (int)(value * Math.Pow(10, multiplier));
        }

        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>resistance, minimum resistance, maximum resistance in ohms</returns>
        public OhmResistance CalculateOhmResistanceValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int value = Convert.ToInt32(string.Format("{0}{1}", _resistorBands.BandAAndB[bandAColor], _resistorBands.BandAAndB[bandBColor]));
            int multiplier = _resistorBands.Multiplier[bandCColor];
            double tolerance = _resistorBands.Tolerance[bandDColor];

            double resistance = value * Math.Pow(10, multiplier);
            double minReistance = resistance * (1 - tolerance);
            double maxResistance = resistance * (1 + tolerance);

            OhmResistance ohmResistance = new OhmResistance
            {
                Resistance = FormatResistanceValuesUtility.FormatValue(resistance),
                MinResistance = FormatResistanceValuesUtility.FormatValue(minReistance),
                MaxResistance = FormatResistanceValuesUtility.FormatValue(maxResistance)
            };

            return ohmResistance;
        }
    }
}
