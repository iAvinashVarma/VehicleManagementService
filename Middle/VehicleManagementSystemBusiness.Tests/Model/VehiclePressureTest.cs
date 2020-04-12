using NUnit.Framework;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Tests.Model
{
    [TestFixture]
    public class VehiclePressureTest
    {
        [Test]
        public void CheckPressurePsiVsPascal()
        {
            var expectedPressurePascal = 206842.80000000002D;
            var givenPressurePsi = 30.0D;
            var vehiclePressure = new VehiclePressure
            {
                PressurePsi = givenPressurePsi
            };

            double actualPressurePascal = vehiclePressure.PressurePascal;

            Assert.AreEqual(expectedPressurePascal, actualPressurePascal);
        }
    }
}
