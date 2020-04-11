using NUnit.Framework;
using System;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Tests.Model
{
    [TestFixture]
    public class VehicleTemperatureTest
    {
        [Test]
        public void CheckTemperatureFVersusC()
        {
            var expectedTemperatureFahrenheit = 66.1972642188625D;
            var givenTemperatureCelsius = 19.0D;
            var vehicleTemperature = new VehicleTemperature
            {
                TemperatureCelsius = givenTemperatureCelsius
            };

            double actualTemperatureF = vehicleTemperature.TemperatureFahrenheit;

            Assert.AreEqual(expectedTemperatureFahrenheit, actualTemperatureF);
        }
    }
}
