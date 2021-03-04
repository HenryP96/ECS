using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;
using ECS.Legacy;
using NSubstitute;

namespace ECS.Tests
{
    [TestFixture]
    public class Tests
    {
        private EnvironmentControlSystem uut;
        private IHeater heater_;
        private ITempSensor tempSensor_;
        int temp;
        [SetUp]
        public void Setup()
        {
            heater_ = Substitute.For<IHeater>();
            tempSensor_ = Substitute.For<ITempSensor>();
            temp = 28;
            uut = new EnvironmentControlSystem(temp, tempSensor_, heater_);
        }

        [Test]
        public void RegulateTest()
        {
            //Act
            uut.Regulate();

            //Arrange
            int result = uut.GetCurTemp();

            //Assert
            Assert.That(result, Is.InRange(-5, 45));
        }

        [Test]
        public void SelfTests()
        {

            //Arrange
            tempSensor_.RunSelfTest().Returns(true);
            bool result = uut.RunSelfTest();

            //Assert
            Assert.Multiple(() =>
            {
                tempSensor_.Received().RunSelfTest();
                heater_.Received().RunSelfTest();
            });
        }


        [Test]
        public void TempSensorRegulateTest()
        {
            //Act
            uut.Regulate();

            //Arrange + Assert
            tempSensor_.Received().GetTemp();
        }

        [Test]
        public void HeaterRegulateTest()
        {
            //Act
            uut.Regulate();

            //Arrange

            //Assert
            if (uut.GetCurTemp() < temp)
            {
                heater_.Received().TurnOn();
            }
            else
            {
                heater_.Received().TurnOff();
            }
        }


        [Test]
        public void ThresholdTest()
        {
            //Act
            uut.SetThreshold(30);

            //Arrange
            int result = uut.GetThreshold();

            //Assert
            Assert.That(result, Is.EqualTo(30));
        }

    }
}