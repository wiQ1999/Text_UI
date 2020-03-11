using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Text_UI
{
    class UI
    {
        #region Properties

        /// <summary>
        /// Represents 2D place for starting text position
        /// </summary>
        public Vector2 InputPosition { get; set; }
        /// <summary>
        /// User updated text variable
        /// </summary>
        private string InputText { get; set; }
        /// <summary>
        /// Represents 2D place for starting statement position
        /// </summary>
        private int InTextLength { get; set; }
        /// <summary>
        /// Maximum Output length in the console
        /// </summary>
        private Vector2 OutputPosition { get; set; }
        /// <summary>
        /// Text shows similar commands to written InputText
        /// </summary>
        private string OutputText { get; set; }
        /// <summary>
        /// Maximum InputText length in the console
        /// </summary>
        private int OutTextLength { get; set; }
        /// <summary>
        /// Text displayed between two suggested words
        /// </summary>
        private string OutputTextSeparator { get; set; }
        /// <summary>
        /// Text displayed at the end of output if the output is longer than maximum length of output
        /// </summary>
        private string OutputTextEnd { get; set; }
        

        #endregion

        #region Ctor

        public UI(int a_iInputPositionX, int a_iInputPositionY, int a_iOutputPositionX, int a_iOutputPositionY, int a_iInTextLength, int a_iOutTextLength, string a_sSeparatorText, string a_sEndText)
        {
            this.InputPosition = new Vector2() { X = a_iInputPositionX, Y = a_iInputPositionY };
            this.InputText = string.Empty;
            this.OutputPosition = new Vector2() { X = a_iOutputPositionX, Y = a_iOutputPositionY };
            this.OutputText = string.Empty;
            this.InTextLength = a_iInTextLength;
            this.OutTextLength = a_iOutTextLength;
            this.OutputTextSeparator = a_sSeparatorText;
            this.OutputTextEnd = a_sEndText;
        }

        #endregion

        #region Methods

        private void DisplayOutput(List<string> a_oSuggestions)
        {
            //Czyszczenie Output'u
            Console.SetCursorPosition(this.OutputPosition.X, this.OutputPosition.Y);
            for(int i = this.OutputPosition.X; i < this.OutTextLength; i++)
            {
                Console.Write(" ");
            }

            //Czyszczenie zmiennej
            this.OutputText = string.Empty;

            //Jeżeli sugerowane wyrazy istnieją
            if (a_oSuggestions != null)
            {
                //Pętla po wszystkich sugerowanych wyrazach
                for(int i = 0; i < a_oSuggestions.Count; i++)
                {
                    //Jeżeli długość jest większa niż dozwolona
                    if (this.OutputText.Length >= this.OutTextLength)
                    {
                        //Ucinanie końcówki tekstu aby zmieścił się w określonej długości
                        this.OutputText = this.OutputText.Remove(this.OutTextLength - this.OutputTextEnd.Length);

                        //Usupełnienie końcówki o podany tekst końcowy
                        this.OutputText += this.OutputTextEnd;

                        //Przerwanie wypisywania
                        break;
                    }

                    //Dodanie wrazu do ciągu znaków Output
                    this.OutputText += a_oSuggestions[i];

                    //Jeżeli nie jest to ostatni wyraz listy
                    if (i + 1 < a_oSuggestions.Count)
                    {
                        //Dodanie textu separującego
                        this.OutputText += this.OutputTextSeparator;
                    }
                }
            }

            //Ustawienie kursora na pozycję output
            Console.SetCursorPosition(this.OutputPosition.X, this.OutputPosition.Y);

            //Wypisanie Output'u
            Console.Write(this.OutputText);
        }

        private void CheckOrder()
        {
            //Deklaracja zminneych
            List<string> _oWords = new List<string>();
            string _sWord = string.Empty;

            //Pętla po każdej literze ciągu znaków wpisanych przez użytkownika
            for (int i = 0; i < this.InputText.Length; i++)
            {
                if (this.InputText[i] != ' ')//Jezeli natrafi na jakąś literę / nie spacebar
                {
                    //Zaktualizowanie wyrazu o znak
                    _sWord += this.InputText[i].ToString();
                }
                else if(this.InputText[i] == ' ' && _sWord != string.Empty)//Jeżeli nie natrafi na literę i jeżeli zmienna wyrazu nie jest pusta
                {
                    //Wpsianie wyrazu do listy
                    _oWords.Add(_sWord);

                    //Zresetowanie zmiennej wyrazu
                    _sWord = string.Empty;
                }
            }

            //Deklaracja obiektu listy
            CommandList list = new CommandList();

            //Wyświetlenie Outputu
            DisplayOutput(list.OrderAnalysis(_oWords));//Lista proponowanych następnych wyrazów jeżeli istnieją
        }

        /// <summary>
        /// Converts console key to single chars
        /// </summary>
        /// <param name="a_key">Console key variable</param>
        /// <returns>Single char</returns>
        private string ConvertibletKeys(ConsoleKey a_key)
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

        /// <summary>
        /// Responsible for reading the and interpretation text in real time
        /// </summary>
        public void AdvancedUI()
        {
            Task inputingText = Task.Run(() =>
            {
                while (true)
                {
                    //Deklaracja zmiennych
                    ConsoleKey _key = ConsoleKey.Spacebar;//Przechowuje konsolową nazwę klawiszy, manualne przypisanie klawisza spacji, aby rozpocząć główną petlę
                    int _iInputPosX = this.InputPosition.X;//Przechowuje pozycje ostatniego miejsca w tekście
                    int _iOutputPosX = this.OutputPosition.X;//Przechowuje pozycje wiadomości zwrotnych

                    //Pętla - działanie na tekscie
                    do
                    {
                        //Deklaracja zmiennych
                        string _sKey = string.Empty;//Przechowuje znak zczytany z klawiatury

                        //Ustawienie pozycji kursora
                        Console.SetCursorPosition(_iInputPosX, this.InputPosition.Y);

                        //Zczytanie klawisza konsolowego z klawiatury
                        _key = Console.ReadKey(true).Key;

                        //Usuwanie jednego znaku - Backspace
                        if (_key == ConsoleKey.Backspace && this.InputText.Length > 0)//Jeżeli wciśnięto Bacspace oraz jeżeli tekst nie jest pusty
                        {
                            //Usunięcie ostatniego znaku z ciągu znaków
                            this.InputText = this.InputText.Remove(this.InputText.Length - 1);

                            //Aktualziacja pozycji X
                            _iInputPosX--;

                            //Usunięcie ostatniego znaku z konsoli
                            Console.SetCursorPosition(_iInputPosX, this.InputPosition.Y);
                            Console.Write(" ");
                        }
                        else if (_key != ConsoleKey.Backspace && this.InputText.Length < this.InTextLength)//Jeżeli nie jest wciśnięty Backspace oraz długość tesktu nie jest za długa
                        {
                            //Sprawdzanie długości nazwy klawisza konsolowego
                            if (_key.ToString().Length > 1)//Jeżeli jest dłuższy niż 2 litery
                            {
                                //Konwersja z kalwisza konsolowego na ASCI
                                _sKey = ConvertibletKeys(_key);
                            }
                            else//Jeżeli ma jedną literę
                            {
                                _sKey = _key.ToString();
                            }

                            //Sprawdzanie czy przekonwertowany znak nie jest pusty
                            if (_sKey != string.Empty)
                            {
                                //Dodanie znaku do ciagu znaków
                                this.InputText += _sKey;

                                //Wyświetlanie tekstu
                                Console.Write(this.InputText[this.InputText.Length - 1]);

                                //Aktualziacja pozycji X
                                _iInputPosX++;
                            }
                        }

                        //Sprawdzenie poprawności komendy
                        CheckOrder();

                    } while (_key != ConsoleKey.Enter);//Dopóki użykownik nie wciśnie Enter

                    //Wyświtlenie komendy
                    /*
                    Console.SetCursorPosition(0, 0);
                    Console.Write(this.InputText);
                    */

                    //Czyszczenie konsoli
                    Console.SetCursorPosition(this.InputPosition.X, this.InputPosition.Y);
                    for(int i = 0; i < this.InputText.Length; i++)
                    {
                        Console.Write(" ");
                    }

                    //Resetowanie zmiennych
                    this.InputText = string.Empty;
                }
            });
        }

        #endregion
    }
}
