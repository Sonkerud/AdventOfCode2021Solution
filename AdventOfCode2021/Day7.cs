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
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day7", "Day7")[0].Split(",").Select(x => int.Parse(x)).ToList();

            long minFuel = long.MaxValue;
            //Loop through every possible horizontal position
            for (int i = todaysInputData.Min(); i <= todaysInputData.Max(); i++)
            {
                long fuelCount = 0;
                long fuelCountPart2 = 0;
                long fuelCountPart2Answer = 0;

                //Count the amount of fuel needed for every crab
                for (int y = 0; y < todaysInputData.Count; y++)
                {
                    fuelCountPart2 = 0;

                    if (todaysInputData[y] < i) 
                    {
                        fuelCount += i - todaysInputData[y];
                        fuelCountPart2 += i - todaysInputData[y];
                    }
                    else if (todaysInputData[y] > i)
                    {
                        fuelCount += todaysInputData[y] - i;
                        fuelCountPart2 += todaysInputData[y] - i;
                    }
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
    }
}
