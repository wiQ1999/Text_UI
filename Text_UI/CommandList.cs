﻿using System.Collections.Generic;

namespace Text_UI
{
    class CommandList
    {
		#region Properties

		/// <summary>
		/// List of commands
		/// </summary>
		public List<Command> Commands { get; set; }

		#endregion

		#region Ctor

		public CommandList()
        {
            //deklaracja listy dostępnych komend
            Commands = new List<Command>();

            //Wyraz 1
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "ADD",
                _bStarted = true,
                _oNextWord = new List<string>() { "COMMAND", "WARMING" }
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "BUY",
                _bStarted = true,
                _oNextWord = new List<string>() { "TOWER", "LEVEL", "HP", "CAR", "SKILL" }
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "SELL",
                _bStarted = true,
                _oNextWord = new List<string>() { "TOWER", "LEVEL", "CAR" }
            });

            //Wyraz 2
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "TOWER",
                _bIsNumeric = true,
                _iMinNumber = 1,
                _iMaxNumber = 3
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "LEVEL",
                _bIsNumeric = true,
                _iMinNumber = 1,
                _iMaxNumber = 8
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "HP",
                _bIsNumeric = true,
                _iMinNumber = 1,
                _iMaxNumber = 100
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "CAR",
                _oNextWord = new List<string>() { "FORD", "FIAT", "MERCEDES", "VOLKSWAGEN" }
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "SKILL",
                _oNextWord = new List<string>() { "FOOTBALL", "PROGRAMMING", "TREATMENT" }
            });

            //Wyraz 3
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "FORD",
                _oNextWord = new List<string> { "FOCUS", "MUSTANG", "MONDEO" }
            });

            //Wyraz 4
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "FOCUS",
                _bIsNumeric = true,
                _iMinNumber = 1998,
                _iMaxNumber = 2008
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "MUSTANG",
                _bIsNumeric = true,
                _iMinNumber = 1964,
                _iMaxNumber = 2020
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "MONDEO",
                _bIsNumeric = true,
                _iMinNumber = 1993,
                _iMaxNumber = 2020
            });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches for next commands
        /// </summary>
        /// <param name="a_sSearchingWord">Previus word</param>
        /// <returns>List of suggest words</returns>
        private List<string> NextCommands(string a_sSearchingWord)
        {
            //Deklaracja zmiennych
            List<string> _oOutput = new List<string>();

            //Pętla po wszystkich komendach
            foreach (Command word in this.Commands)
            {
                //Jeżeli szukane słowo jest zgodne z elementem w liście
                if (word._sCurrentWord == a_sSearchingWord)
                {
                    //Dodaj listę nastepnych słów do listy wyjściowej
                    if(word._oNextWord != null)//Jeżelu lista następnych komend nie jest pusta
                        _oOutput = word._oNextWord;

                    //Jeżeli określono istnienie zakresu lcizbowego
                    if(word._bIsNumeric == true)
                    {
                        //Pętla po zakresie liczbowym
                        for (int i = word._iMinNumber; i <= word._iMaxNumber; i++)
                        {
                            //Dodanie liczby do listy
                            _oOutput.Add(i.ToString());
                        }
                    }

                    //Przerwij szukanie
                    break;
                }
            }

            //Zwrócenie startowych komend
            return _oOutput;
        }

        /// <summary>
        /// Searches for next commands, used for starting words command
        /// </summary>
        /// <returns>List of suggest words</returns>
        private List<string> NextCommands()
        {
            //Deklaracja zmiennych
            List<string> _oOutput = new List<string>();

            //Pętla po wszystkich komendach
            foreach (Command word in this.Commands)
            {
                //Jeżeli są to startowe komendy
                if (word._bStarted == true)
                    _oOutput.Add(word._sCurrentWord);//Przypisanie słowa do listy
            }

            //Zwrócenie startowych komend
            return _oOutput;
        }

        /// <summary>
        /// Analyzes given list of words and connect with next suggest words
        /// </summary>
        /// <param name="a_oWords">List of words written by user</param>
        /// <returns>List of next suggest words</returns>
        public List<string> OrderAnalysis(List<string> a_oWords)
        {
            //Deklaracja zmiennych
            List<string> _oOutput = new List<string>();

            if(a_oWords == null || a_oWords.Count == 0)//Jeżeli lista wyrazów jest psuta
            {
                //Zwrócenie listy początkowych wyrazów
                return NextCommands();
            }
            else//Jeżeli lista wyrazów nie jest psuta
            {
                //Deklaracja listy sugerowanych komend
                List<string> _oSuggestion = NextCommands();

                //Sprawdzanie każdego wyrazu z listy wyrazów
                for (int i = 0; i < a_oWords.Count; i++)
                {
                    //zmienna określająca czy konkretny wyraz w liście wystepuje w liście proponowanych
                    bool _bIsCorrect = false;

                    //Jezeli lista seugerowanych komend jest pusta
                    if (_oSuggestion == null || _oSuggestion.Count == 0)
                    {
                        break;//Brak sugerowanych wyrazów
                    }
                    else
                    {
                        //Pętla po sugerowanych wyrazach
                        for (int x = 0; x < _oSuggestion.Count; x++)
                        {
                            //Jezeli sugerowany wyraz jest taki sam jak wyraz w liście wyrazów
                            if (_oSuggestion[x] == a_oWords[i])
                            {
                                _bIsCorrect = true;
                                break;
                            }
                        }

                        //Jezeli komenda jest niepoprawna
                        if (_bIsCorrect == false)
                        {
                            //Dodanie komunikatu błędu
                            _oOutput.Add(a_oWords[i] + " not found!");
                            return _oOutput;
                        }

                        //aktualizacja sugerowanej listy
                        _oSuggestion = NextCommands(a_oWords[i]);
                    }
                }

                //Nadmisanie Output'u sugerowanymi komendami
                _oOutput = _oSuggestion;

                //Zwrócenie listy sugerowanych nastepnych wyrazów
                return _oOutput;
            }
        }

		#endregion
	}
}
