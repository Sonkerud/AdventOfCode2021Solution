using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Inputreader
    {
        public static List<int> ReadTxt(string day)
        {
            var inputDataList = File.ReadAllLines($"C:\\Users\\sonerale\\OneDrive - TietoEVRY\\Evry\\AdventOfCode2021\\{day}\\{day}.txt").ToList().Select(x => int.Parse(x)).ToList();

            return inputDataList;
        
        }

    }
}
