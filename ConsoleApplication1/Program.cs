using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MoveCursorApplication
{
    public class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetCursorPos(int X, int Y);

        static void Main(string[] args)
        {
            MoveMouse();
        }

        public static void MoveMouse()
        {
            var rand = new Random();
            var timer = new Stopwatch();

            timer.Start();

            Console.WriteLine($"Press escape to stop program!");
            while (timer.IsRunning)
            {
                var timerIsDivisibleByFiveSeconds = timer.ElapsedMilliseconds % 5000 == 0;
                var youClickedEscapeKey = Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Escape;

                if (timerIsDivisibleByFiveSeconds) { SetCursorPos(rand.Next(100), rand.Next(100)); }
                else if (youClickedEscapeKey) { timer.Stop(); }
            }
        }
    }
}
