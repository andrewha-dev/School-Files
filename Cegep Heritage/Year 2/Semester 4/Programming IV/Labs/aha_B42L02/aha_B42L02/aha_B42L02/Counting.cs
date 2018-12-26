using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_B42L02
{
    public class Counting
    {
        public int countNumber(String _string)
        {
            return _string.Count(char.IsDigit);
        }

        public int countNumbers(Int64 _theInt)
        {
            return countNumber(Convert.ToString(_theInt));
        }
        public int countLetters(String _input)
        {
            return _input.Count(char.IsLetter);
        }
    }

    
}
