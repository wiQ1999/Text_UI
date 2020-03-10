using System;
using System.Collections.Generic;
using System.Text;

namespace Text_UI
{
    class CommandList
    {
        public List<Command> Commands { get; set; }

		#region Ctor

		public CommandList()
        {
            //deklaracja listy dostępnych komend
            Commands = new List<Command>();

            //Wyraz 1
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "BUY",
                _oNextWord = new List<string>() { "TOWER", "LEVEL", "HP", "CAR", "SKILL" }
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "SELL", 
                _oNextWord = new List<string>() { "TOWER", "LEVEL", "CAR" }
            });

            //Wyraz 2
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "TOWER", 
                _iMinNumber = 1, 
                _iMaxNumber = 3
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "LEVEL",
                _iMinNumber = 1,
                _iMaxNumber = 8
            });
            this.Commands.Add(new Command()
            {
                _sCurrentWord = "HP",
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

        }

		#endregion

		#region Methods

        public List<string> OrderAnalysis(List<string> a_oWords)
        {
            int i = 0;

            foreach (string word in a_oWords)
            {


                i++;
            }

            return this.Commands[i]._oNextWord;
        }

		#endregion
	}
}
