using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day3
    {
        public static void Day3Part1Calculator()
        {
            var todaysInputData = Inputreader.ReadTxtString("Day3", "Day3");
            
            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < todaysInputData[0].Length; i++)
            {
                if (todaysInputData.Select(x => int.Parse(x[i].ToString())).ToList().Sum() > todaysInputData.Count / 2)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }
            int gammaInt = Convert.ToInt32(gamma, 2);
            int epsilonInt = Convert.ToInt32(epsilon, 2);
            Console.WriteLine(gammaInt + " * " + epsilonInt + " = " + gammaInt * epsilonInt);

        }

        public static void Day3Part2Calculator()
        {
            var todaysInputData = Inputreader.ReadTxtString("Day3", "Day3");
            List<string> filteredListOGR = todaysInputData;
            List<string> filteredListCSR = todaysInputData;
            int ogr = 0;
            int csr = 0;

            for (int i = 0; i < todaysInputData[0].Length; i++)
            {   
                if (filteredListOGR.Count > 1)
                {
                    filteredListOGR = FilterList(filteredListOGR, i, "ogr");
                    if(filteredListOGR.Count == 1)
                    {
                        ogr = Convert.ToInt32(filteredListOGR[0], 2);
                    }
                }

                if (filteredListCSR.Count > 1)
                {
                    filteredListCSR = FilterList(filteredListCSR, i, "csr");
                    if (filteredListCSR.Count == 1)
                    {
                        csr = Convert.ToInt32(filteredListCSR[0], 2); 
                    }
                }
            }
            Console.WriteLine("ogr: " + ogr + " * csr: " + csr + " = " + ogr * csr);
        }

        public static List<string> FilterList(List<string> todaysInputData, int i, string ogrOrcsr)
        {
            int nrOf1 = todaysInputData.Where(x => x[i].Equals('1')).ToList().Count;
            int nrOf0 = todaysInputData.Where(x => x[i].Equals('0')).ToList().Count;

            if (nrOf1 > nrOf0 || nrOf1 == nrOf0) 
            {
                var output = ogrOrcsr == "ogr" 
                            ? todaysInputData.Where(x => x[i].Equals('1')).ToList() 
                            : todaysInputData.Where(x => x[i].Equals('0')).ToList();
                return output;
            }
            else 
            {
                var output = ogrOrcsr == "ogr"
                            ? todaysInputData.Where(x => x[i].Equals('0')).ToList()
                            : todaysInputData.Where(x => x[i].Equals('1')).ToList();
                return output;
            }
        }
    }
}
