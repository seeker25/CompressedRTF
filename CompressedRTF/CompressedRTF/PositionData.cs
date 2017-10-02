using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressedRTF
{
    public class PositionData
    {
        public int DictionaryOffset { get; set; }
        public int LongestMatchLength;
        public int WriteOffset { get; set; }
    }
}
