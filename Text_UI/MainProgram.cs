using System;
using System.Threading;

namespace Text_UI
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            #region Console_Settings

            Console.BufferHeight = 60;
            Console.WindowHeight = 20;

            #endregion

            //Pozycja w konsoli tekstu wejściowego
            int InputPositionX = 0;//X
            int InputPositionY = 10;//Y

            //Pozycja w konsoli tekstu wyjściowego
            int OutputPositionX = 2;//X
            int OutputPositionY = 11;//Y

            //Długość tekstów
            int InputLength = 30;//Długość tekstu wejściowego
            int OutputLength = 20;//Długość tekstu wyjściowego

            //Znaki specjalne
            string Separator = ", ";//Wyświetlany pomiędzy dwoma wyrazami na wyjściu
            string EndText = "...";//Wyświetlany na końcu tekstu na wyjściu gdy brakuje miejsca do wyświetlenia


            //Inicjalizacja interfejsu tektowego użytkownika
            UI ui = new UI(InputPositionX, InputPositionY, OutputPositionX, OutputPositionY, InputLength, OutputLength, Separator, EndText);
            ui.AdvancedUI();

			#region Simulation

			//Symulacja pracy programu
			while (true)
            {
                Thread.Sleep(1000);
            }

			#endregion

			//Console.ReadKey();
		}
	}
}
