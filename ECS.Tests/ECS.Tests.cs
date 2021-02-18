using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;
using ECS.Legacy;

namespace ECS.Tests
{
    [TestFixture]
    public class Tests
    {
        private EnviromentControlSystem uut;
        [SetUp]
        public void Setup()
        {
            var uut = new EnviromentControlSystem(28, new FakeTempSensor(), new FakeHeater());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}