using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aha_HVK
{
    [Serializable]
    public class KennelLog
    {
        public DateTime date { get; set; }
        public int number { get; set; }
        public String notes { get; set; }
        public byte video { get; set; }

        public KennelLog()
        {
            date = new DateTime(1000, 1, 1);
            number = -1;
            notes = "";
            video = 0;
        }
        public KennelLog(DateTime _logDate, int _logNumber,String _logNotes)
        {
            date = _logDate;
            number = _logNumber;
            notes = _logNotes;
            video = 0;
        }
        public KennelLog(DateTime _logDate, int _logNumber, String _logNotes, byte _logVideo)
        {
            date = _logDate;
            number = _logNumber;
            notes = _logNotes;
            video = _logVideo;
        }
    }
}
