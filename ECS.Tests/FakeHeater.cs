using System;
using System.Collections.Generic;
using System.Text;
using ECS.Legacy;

namespace ECS.Tests
{
    class FakeHeater : IHeater
    {
        public void TurnOn()
        {
            Console.WriteLine("FakeHeater is now turned on");
        }
        public void TurnOff()
        {
            Console.WriteLine("FakeHeater is now turned off");
        }

        public bool RunSelfTest()
        {
            return true;
        }

    }
}
