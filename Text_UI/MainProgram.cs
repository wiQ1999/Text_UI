using System;
using System.Collections.Generic;
using System.Threading;

namespace Text_UI
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> orders1 = new Dictionary<string, List<string>>();
            orders1.Add("BUY", new List<string>() { "LVL", "TIER", "HP" });
            orders1.Add("SELL", new List<string>() { "LVL", "TIER" });
            orders1.Add("SPEED", new List<string>() { "1", "2", "3" });
            orders1.Add("START", new List<string>() { });

            Dictionary<string, List<int>> orders2 = new Dictionary<string, List<int>>();
            orders2.Add("LVL", new List<int> { 1, 2, 3, 4, 5 });
            orders2.Add("TIER", new List<int> { 1, 2, 3, 4, 5 });
            orders2.Add("HP", new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90 });






            foreach (var item in orders1)
            {
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2);
                }
            }
            


            UI ui = new UI(0, 10, 0, 11, 30);

            ui.AdvancedUI();


            while (true)
            {
                Thread.Sleep(1000);
            }

            //Console.ReadKey();
        }
    }
}
