using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resistor;
using Resistor.Models;

namespace ResistorTests
{
    [TestClass]
    public class ResistorUnitTests
    {
        [TestMethod]
        public void CalculateZeroOhmValueTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();

            int value = calculateOhmValues.CalculateOhmValue("black", "black", "pink", "white");

            //Assert
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void CalculateOhmValueTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();
            int value = calculateOhmValues.CalculateOhmValue("yellow", "green", "blue", "silver");

            //Assert
            Assert.AreEqual(45000000, value);
        }

        [TestMethod]
        public void CalculateOhmResistanceValuesTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();
            OhmResistance value = calculateOhmValues.CalculateOhmResistanceValues("black", "red", "orange", "grey");

            //Assert
            Assert.AreEqual("2000", value.Resistance);
            Assert.AreEqual("1999", value.MinResistance);
            Assert.AreEqual("2001", value.MaxResistance);
        }

        [TestMethod]
        public void CalculateSmallOhmResistanceValuesTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();
            OhmResistance value = calculateOhmValues.CalculateOhmResistanceValues("red", "green", "silver", "violet");

            //Assert
            Assert.AreEqual("0.25", value.Resistance);
            Assert.AreEqual("0.24975", value.MinResistance);
            Assert.AreEqual("0.25025", value.MaxResistance);
        }

        [TestMethod]
        public void CalculateKiloOhmResistanceValuesTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();
            OhmResistance value = calculateOhmValues.CalculateOhmResistanceValues("brown", "orange", "green", "gold");

            //Assert
            Assert.AreEqual("1300.0K", value.Resistance);
            Assert.AreEqual("1235.0K", value.MinResistance);
            Assert.AreEqual("1365.0K", value.MaxResistance);
        }

        [TestMethod]
        public void CalculateMegaOhmResistanceValuesTestMethod()
        {
            CalculateOhmValues calculateOhmValues = new CalculateOhmValues();
            OhmResistance value = calculateOhmValues.CalculateOhmResistanceValues("grey", "green", "white", "white");

            //Assert
            Assert.AreEqual("85000.0M", value.Resistance);
            Assert.AreEqual("68000.0M", value.MinResistance);
            Assert.AreEqual("102000.0M", value.MaxResistance);
        }
    }
}
