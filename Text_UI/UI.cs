using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Text_UI
{
    class UI
    {
        #region Properties

        public Vector2 InputPosition { get; set; }
        private string InputText { get; set; }
        private Vector2 OutputPosition { get; set; }
        private string OutputText { get; set; }
        private int MaxTextLength { get; set; }

        #endregion

        #region Ctor

        public UI(int a_iInputPositionX, int a_iInputPositionY, int a_iOutputPositionX, int a_iOutputPositionY, int a_iMaxLength)
        {
            this.InputPosition = new Vector2() { X = a_iInputPositionX, Y = a_iInputPositionY };
            this.InputText = string.Empty;
            this.OutputPosition = new Vector2() { X = a_iOutputPositionX, Y = a_iOutputPositionY };
            this.OutputText = string.Empty;
            this.MaxTextLength = a_iMaxLength;
        }

        #endregion

        #region Methods

        private string CheckKeys(ConsoleKey a_key)
        {
            //Deklaracja zmiennych
            string _sChar = string.Empty;

            //Sprawdzanie klawisza
            switch (a_key)
            {
                case ConsoleKey.D0:
                    _sChar = "0";
                    break;
                case ConsoleKey.D1:
                    _sChar = "1";
                    break;
                case ConsoleKey.D2:
                    _sChar = "2";
                    break;
                case ConsoleKey.D3:
                    _sChar = "3";
                    break;
                case ConsoleKey.D4:
                    _sChar = "4";
                    break;
                case ConsoleKey.D5:
                    _sChar = "5";
                    break;
                case ConsoleKey.D6:
                    _sChar = "6";
                    break;
                case ConsoleKey.D7:
                    _sChar = "7";
                    break;
                case ConsoleKey.D8:
                    _sChar = "8";
                    break;
                case ConsoleKey.D9:
                    _sChar = "9";
                    break;
                case ConsoleKey.Spacebar:
                    _sChar = " ";
                    break;
            }

            //Zwracanie litery
            return _sChar;
        }

        public void AdvancedUI()
        {
            Task text = Task.Run(() =>
            {
                while (true)
                {
                    //Deklaracja zmiennych
                    ConsoleKey _key = ConsoleKey.Spacebar;//Przechowuje konsolową nazwę klawiszy, manualne przypisanie losowego klawisza aby rozpocząć główną petlę

                    //Pętla - działanie na tekscie
                    while (_key != ConsoleKey.Enter)//Dopóki użykownik nie wciśnie Enter
                    {
                        //Deklaracja zmiennych
                        string _sKey = string.Empty;

                        //Ustawienie pozycji kursora
                        Console.SetCursorPosition(this.InputPosition.X, this.InputPosition.Y);

                        //Zczytanie klawisza z klawiatury
                        _key = Console.ReadKey(true).Key;

                        //Usuwanie jednego znaku - Backspace
                        if (_key == ConsoleKey.Backspace && this.InputText.Length > 0)//Jeżeli wciśnięto Bacspace oraz jeżeli tekst nie jest pusty
                        {
                            //Usunięcie ostatniego znaku z ciągu znaków
                            this.InputText = this.InputText.Remove(this.InputText.Length - 1);

                            //Aktualziacja pozycji X
                            this.InputPosition = new Vector2() { X = this.InputPosition.X - 1, Y = this.InputPosition.Y };

                            //Usunięcie ostatniego znaku z konsoli
                            Console.SetCursorPosition(this.InputPosition.X, this.InputPosition.Y);
                            Console.Write(" ");

                        }
                        else if(_key != ConsoleKey.Backspace && this.InputText.Length < this.MaxTextLength)//Jeżeli nie jest wciśnięty Backspace oraz długość tesktu nie jest za długa
                        {
                            //Sprawdzanie długości nazwy klawisza funkcjonalnego konsoli
                            if (_key.ToString().Length > 1)//Jeżeli jest dłuższy niż 2 litery
                            {
                                _sKey = CheckKeys(_key);
                            }
                            else//Jeżeli ma jedną literę
                            {
                                _sKey = _key.ToString();
                            }

                            //Dodanie znaku do ciagu znaków
                            this.InputText += _sKey;

                            //Wyświetlanie tekstu
                            Console.Write(this.InputText[this.InputText.Length - 1]);

                            //Aktualziacja pozycji X
                            this.InputPosition = new Vector2() { X = this.InputPosition.X + 1, Y = this.InputPosition.Y };
                        }
                    }

                    //Czyszczenie konsoli i zmiennych
                    Console.Clear();

                }
            });
        }

        #endregion
    }
}
