using System;

namespace Sokoban
{
    
    public class Exception_MazeIncorrectFileFormat : ApplicationException
    {
        private char _unrecognisedCharacter;

        public Exception_MazeIncorrectFileFormat(char onbekendteken)
        {
            _unrecognisedCharacter = onbekendteken;
        }

        public override string ToString()
        {
            return string.Concat("Cannot parse Maze file, unkown character: `", _unrecognisedCharacter, "`");
        }
    }
}
