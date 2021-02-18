namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var ecs = new EnviromentControlSystem(28, new TempSensor(), new Heater());

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();

            System.Console.ReadLine();
        }
    }
}
