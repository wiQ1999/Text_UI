using System;
using System.Threading;

namespace Text_UI
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            
            UI ui = new UI(0, 10, 0, 11, 30);

            ui.AdvancedUI();


            while (true)
            {
                Thread.Sleep(10000);
            }

            //Console.ReadKey();
        }
    }
}
