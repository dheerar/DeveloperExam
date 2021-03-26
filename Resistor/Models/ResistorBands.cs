using System.Collections.Generic;

namespace Resistor.Models
{
    public class ResistorBands
    {
        // Band A and Band B significant figure color codes
        public Dictionary<string, int> BandAAndB;
        // Band C multiplier color codes
        public Dictionary<string, int> Multiplier;
        // Band D tolerance color codes
        public Dictionary<string, double> Tolerance;

        public ResistorBands()
        {
            InitializeBandAAndB();
            InitializeMultiplier();
            InitializeTolerance();
        }

        private void InitializeBandAAndB()
        {
            BandAAndB = new Dictionary<string, int> {
                    {"black", 0},
                    {"brown", 1},
                    {"red", 2},
                    {"orange", 3},
                    {"yellow", 4},
                    {"green", 5},
                    {"blue", 6},
                    {"violet", 7},
                    {"grey", 8},
                    {"white", 9}
             };
        }

        private void InitializeMultiplier()
        {
            Multiplier = new Dictionary<string, int> {
                    {"pink", -3},
                    {"silver",  -2},
                    {"gold",  -1},
                    {"black", 0},
                    {"brown", 1},
                    {"red", 2},
                    {"orange",3},
                    {"yellow", 4},
                    {"green", 5},
                    {"blue",  6},
                    {"violet", 7},
                    {"grey", 8},
                    {"white", 9}
            };
        }

        private void InitializeTolerance()
        {
            Tolerance = new Dictionary<string, double> {
                    {"white", 0.2},
                    {"silver", 0.1},
                    {"gold", 0.05},
                    {"brown",  0.01},
                    {"red", 0.02},
                    {"yellow", 0.05},
                    {"green", 0.005},
                    {"blue", 0.0025},
                    {"violet", 0.001},
                    {"grey", 0.0005}
            };
        }
    }
}
