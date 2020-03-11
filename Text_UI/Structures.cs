using System;
using System.Collections.Generic;
using System.Text;

namespace Text_UI
{
    /// <summary>
    /// 2D place in the console
    /// </summary>
    struct Vector2
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// Struct where command options are storage 
    /// </summary>
    struct Command
    {
        public string _sCurrentWord;
        public bool _bStarted;
        public List<string> _oNextWord;
        public int _iMinNumber;
        public int _iMaxNumber;
    }
}
