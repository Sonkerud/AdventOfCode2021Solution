using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventOfCode2021
{
    public class Day1
    {
        Inputreader Reader = new Inputreader();

        public static void Day1Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtInt("Day1","Day1");
            Console.WriteLine(todaysInputData.Where((x, i) => i > 0 && x > todaysInputData[i - 1]).ToList().Count.ToString());
        }


        

        public static void Day1Part2Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtInt("Day1","Day1");

            Console.WriteLine(todaysInputData.Select((x, i) =>
            i< todaysInputData.Count - 3 &&
            todaysInputData.GetRange(i,3).Sum() < todaysInputData.GetRange(i+1, 3).Sum() ?
            x = 1 : 0).ToList().Sum().ToString());
        }
    }
}
