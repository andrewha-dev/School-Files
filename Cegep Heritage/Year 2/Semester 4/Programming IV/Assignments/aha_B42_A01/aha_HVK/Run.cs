using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class Run
    {
        public int number { get; set; }
        public char size { get; set; }
        public char covered { get; set; }
        public char location { get; set; }
        public int status { get; set; }
        public Run()
        {
            number = -1;
            size = 'U';
            covered = 'U';
            location = 'O';
            status = -1;
        }
        public Run(int _number, char _size)
        {
            number = _number;
            size = _size;
            covered = 'U';
            location = 'U';
            status = -1;
        }
        public Run(int _number, char _size, char _covered, char _location, int _status)
        {
            number = _number;
            size = _size;
            covered = _covered;
            location = _location;
            status = _status;
        }
    }
}
