using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day6
    {
        public static void Day6Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day6", "Day6").ToArray()[0].Split(",").ToList().Select(nr => int.Parse(nr)).ToList();
            List<long> fishList = new List<long> { 0, 0, 0, 0, 0, 0, 0, 0,0 };
            List<long> tempfishList = new List<long> {0,0,0,0,0,0,0,0,0};

            foreach (var item in todaysInputData)
            {
                fishList[item]++;
                tempfishList[item]++;   
            }

            for (int i = 0; i < 256; i++)
            {
               
                for (int y = 1; y < fishList.Count(); y++)
                {
                    tempfishList[y-1] = fishList[y];
                    tempfishList[8] = 0;
                }
                tempfishList[6] += fishList[0];
                tempfishList[8] += fishList[0];

                fishList = fishList.Select((x, i) => x = tempfishList[i]).ToList();
            }
            Console.WriteLine(fishList.Sum());
        }
    }
}
