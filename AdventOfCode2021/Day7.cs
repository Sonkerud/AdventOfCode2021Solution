using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day7
    {
        public static void Day7Calculator(bool isPart2)
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day7", "Day7test")[0].Split(",").Select(x => int.Parse(x)).ToList();

            long minFuel = long.MaxValue;

            //Loop through every possible horizontal position
            for (int i = todaysInputData.Min(); i <= todaysInputData.Max(); i++)
            {
                long fuelCount = 0, fuelCountPart2 = 0, fuelCountPart2Answer = 0;

                //Count the amount of fuel needed for every crab
                for (int y = 0; y < todaysInputData.Count; y++)
                {
                    fuelCountPart2 = 0;

                    fuelCount += Math.Abs(i - todaysInputData[y]);
                    fuelCountPart2 += Math.Abs(i - todaysInputData[y]);

                    //Part2 add extra fuel
                    for (int o = 1; o <= fuelCountPart2; o++)
                    {
                        fuelCountPart2Answer += o;
                    }
                }

                //Set correct answer              
                if (isPart2)
                {
                    if (fuelCountPart2Answer < minFuel)
                    {
                        minFuel = fuelCountPart2Answer;
                    }
                }
                else
                {
                    if (fuelCount < minFuel)
                    {
                        minFuel = fuelCount;
                    }
                }
            }
            Console.WriteLine(minFuel);
        }
        //long Day7_2(string input)
        //{
        //    var positions = AdventOfCode2021.Inputreader.ReadTxtString("Day7", "Day7test")[0].Split(",").Select(x => int.Parse(x)).ToList();

        //    return FuelCosts().Min();

        //    IEnumerable<long> FuelCosts()
        //    {
        //        var start = positions.Min();
        //        var count = positions.Max() - start + 1;

        //        return Enumerable.Range(start, count).Select(pos => positions.Sum(x => SumOfN(Math.Abs(pos - x))));
        //    }
        //    //long FuelCost(int pos) => positions.Sum(x => SumOfN(Math.Abs(pos - x)));

        //    long SumOfN(long n) => n * (n + 1) / 2;
        //} 
    }
}
