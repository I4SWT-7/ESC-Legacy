using System;
using System.Runtime.InteropServices;

namespace ECS.Legacy
{
    public class Application
    {
        public static void Main(string[] args)
        {
            var fakeecs = new ECS(25, 28, new FakeTempSensor(), new FakeHeater());

            System.Console.WriteLine(fakeecs.RunSelfTest());

            fakeecs.Regulate();

            fakeecs.SetThreshold(0,0);

            fakeecs.Regulate();

            System.Console.WriteLine(fakeecs.RunSelfTest());

            System.Console.ReadKey();


        }
    }
}
