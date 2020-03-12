using System.Collections.Generic;

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
        /// <summary>
        /// Current word
        /// </summary>
        public string _sCurrentWord;
        /// <summary>
        /// Represents bool value tells whether the word is used first
        /// </summary>
        public bool _bStarted;
        /// <summary>
        /// List of nest suggest commands
        /// </summary>
        public List<string> _oNextWord;
        /// <summary>
        /// Represents bool value tells whether number range commands is used
        /// </summary>
        public bool _bIsNumeric;
        /// <summary>
        /// Minimum number as command
        /// </summary>
        public int _iMinNumber;
        /// <summary>
        /// Maximum number as command
        /// </summary>
        public int _iMaxNumber;
    }
}
