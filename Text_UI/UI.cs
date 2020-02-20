using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Text_UI
{
    class UI
    {
        #region Properties

        public Vector2 InsertPosition { get; set; }
        private string InsertText { get; set; }
        public Vector2 OutputPosition { get; set; }
        private string OutputText { get; set; }
        public int MacTextLength { get; set; }

        #endregion

        #region Ctor

        public UI()
        {
            this.InsertPosition = new Vector2() { X = 0, Y = 10 };
            this.InsertText = string.Empty;
            this.OutputPosition = new Vector2() { X = 0, Y = 11 };
            this.OutputText = string.Empty;
            this.MacTextLength = 30;
        }

        #endregion

        #region Methods

        private char CheckKeys(ConsoleKey a_key)
        {
            return 'w';
        }

        public void AdvancedUI()
        {
            Task text = Task.Run(() =>
           {
               while (true)
               {
                   //Deklaracja zmiennych
                   ConsoleKey _key = ConsoleKey.Spacebar;//Przechowuje konsolową nazwę klawiszy

                   while(_key != ConsoleKey.Enter)
                   {
                       //Zczytanie klawisza z klawiatury
                       _key = Console.ReadKey(true).Key;

                       char _cKey = CheckKeys(_key);

                       if(_key == ConsoleKey.Backspace && this.InsertText.Length > 0)
                       {
                           this.InsertText.Remove(this.InsertText.Length - 1);
                       }



                   }
               }
           });
        }

        #endregion
    }
}
