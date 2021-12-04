using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class BoardSquare
    {
        public int Number { get; set; }
        public bool Hit { get; set; }

        public int NumberOfHits { get; set; }

        public List<int>? DrawnNumbers { get; set; }
    }
}
