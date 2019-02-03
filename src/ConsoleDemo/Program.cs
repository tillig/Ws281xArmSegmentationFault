using System;
using System.Drawing;
using System.Threading;
using AddressableLed;

namespace ConsoleDemo
{
    /// <summary>
    /// Simple console app to test manual integration with the WS281x library.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var settings = new Settings(new Channel(540, StripType.WS2811_STRIP_GRB, brightness: 64));

            // using (ILedController controller = new StubLedController(settings))
            using (ILedController controller = new Ws281xController(settings))
            {
                // Simple for now - just wipe red, then clear the lights.
                var animation = new ColorWipe(controller, Color.Red);
                Console.WriteLine(animation.ToString());
                animation.Execute(CancellationToken.None);

                var off = new ColorWipe(controller, Color.Black);
                off.Execute(CancellationToken.None);
                Console.WriteLine("Done.");
            }
        }
    }
}
