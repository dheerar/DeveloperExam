using Resistor.Models;

namespace Resistor
{
    public interface ICalculateOhmValues
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>resistance in ohms</returns>
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);

        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal muliplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        /// <returns>resistance, minimum resistance, maximum resistance in ohms</returns>
        OhmResistance CalculateOhmResistanceValues(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }
}
