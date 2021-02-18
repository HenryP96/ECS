using System;

namespace ECS.Legacy
{
    internal class TempSensor : ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            int temp = gen.Next(-5, 45);
            Console.WriteLine($"Temperature is: {temp} degrees");
            return temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }



    public interface ITempSensor
    {
        int GetTemp();

        bool RunSelfTest();
    }
}