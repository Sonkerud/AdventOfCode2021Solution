using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Inputreader
    {
        public static List<int> ReadTxtInt(string dayFolder, string dayTxt)
        {
            var inputDataList = File.ReadAllLines($"C:\\Users\\sonerale\\OneDrive - TietoEVRY\\Evry\\AdventOfCode2021\\{dayFolder}\\{dayTxt}.txt").ToList().Select(x => int.Parse(x)).ToList();

            return inputDataList;
        
        }

        public static List<string> ReadTxtString(string dayFolder, string dayTxt)
        {
            var inputDataList = File.ReadAllLines($"C:\\Users\\sonerale\\OneDrive - TietoEVRY\\Evry\\AdventOfCode2021\\{dayFolder}\\{dayTxt}.txt").ToList();

            return inputDataList;

        }

    }
}
