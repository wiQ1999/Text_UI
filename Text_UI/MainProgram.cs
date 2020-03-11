using System;
using System.Collections.Generic;
using System.Threading;

namespace Text_UI
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            UI ui = new UI(0, 10, 0, 11, 30, 20, ", ", "...");

            ui.AdvancedUI();
            

            //Symulacja pracy programu
            while (true)
            {
                Thread.Sleep(1000);
            }

            //Console.ReadKey();
        }
    }
}
