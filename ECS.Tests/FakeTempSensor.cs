using System;
using System.Collections.Generic;
using System.Text;
using ECS.Legacy;

//This 'fake' class is placed in the test project, due to the fact that the class TempSensor is an internal class.

namespace ECS.Tests
{
    internal class FakeTempSensor : ITempSensor
    {
        public int GetTemp()
        {
            return 25;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
