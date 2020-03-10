using System;
using System.Collections.Generic;
using System.Text;

namespace Text_UI
{
    struct Command
    {
        public string _sCurrentWord;
        //public string _sLastWord;
        public List<string> _oNextWord;
        public int _iMinNumber;
        public int _iMaxNumber;
    }

    class CommandList
    {
        public List<Command> Commands { get; set; }


        public CommandList()
        {
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


    }
}
