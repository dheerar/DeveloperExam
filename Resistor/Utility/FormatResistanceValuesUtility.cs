namespace Resistor.Utility
{
    public static class FormatResistanceValuesUtility
    {
        /// <summary>
        /// Formats resistance values in kilo or mega ohms
        /// </summary>
        /// <param name="resistance">resistance value</param>
        /// <returns>resistance value</returns>
        public static string FormatValue(double resistance)
        {
            if (resistance >= 100000000)
            {
                return (resistance / 1000000).ToString("#.0M"); // mega ohms
            }
            else if (resistance >= 10000000)
            {
                return (resistance / 1000000).ToString("0.#") + "M"; // mega ohms
            }
            //to show in Kilo format
            else if (resistance >= 100000)
            {
                return (resistance / 1000).ToString("#.0K"); // kilo ohms
            }
            else if (resistance >= 10000)
            {
                return (resistance / 1000).ToString("0.#") + "K"; // kilo ohms
            }
            return resistance.ToString();
        }
    }
}
