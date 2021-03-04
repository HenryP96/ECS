using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;
using ECS.Legacy;
using NSubstitute;

namespace ECS.Tests
{
    [TestFixture]
    public class Tests
    {
        private EnviromentControlSystem uut;
        private IHeater heater_;
        private ITempSensor tempSensor_;
        int temp;
        [SetUp]
        public void Setup()
        {
            heater_ = Substitute.For<IHeater>();
            tempSensor_ = Substitute.For<ITempSensor>();
            temp = 28;
            uut = new EnviromentControlSystem(temp, tempSensor_, heater_); ;
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
            //When a specific result is needed, NSubstitute will SUCK BIG TIME
            //Act
            var uut2 = new EnviromentControlSystem(temp, new FakeTempSensor(), new FakeHeater());

            //Arrange
            bool result = uut2.RunSelfTest();

            //Assert
            Assert.That(result, Is.EqualTo(true));
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

    }
}