using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Exception_GameBoardIncorrectFileFormat : ApplicationException
    {
        private char _unrecognisedCharacter;

        public Exception_GameBoardIncorrectFileFormat(char onbekendteken)
        {
            _unrecognisedCharacter = onbekendteken;
        }

        public override string ToString()
        {
            return string.Concat("Cannot parse GameBoard file, unkown character: `", _unrecognisedCharacter, "`");
        }
    }
}
