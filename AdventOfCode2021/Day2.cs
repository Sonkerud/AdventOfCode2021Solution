using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day2
    {

        public static void Day2Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day2", "Day2");
            int forward = 0;
            int depth = 0;

            foreach (var instruction in todaysInputData)
            {
                var direction = instruction.ToString().Substring(0, instruction.Length - 2);
                var distance = int.Parse(instruction.ToString().Substring(instruction.Length - 1, 1));

                switch (direction)
                {
                    case "forward": forward += distance; break;
                    case "up": depth -= distance; break;
                    case "down": depth += distance; break;
                }
            }
            Console.WriteLine((forward * depth).ToString());
        }

        public static void Day2Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day2","Day2");
            int forward = 0;
            int depth = 0;
          
            foreach (var instruction in todaysInputData)
            {
                var direction = instruction.ToString().Substring(0,instruction.Length - 2);
                var distance =  int.Parse(instruction.ToString().Substring(instruction.Length - 1, 1));

                switch (direction)
                {
                    case "forward": forward += distance; break;
                    case "up":  depth -= distance; break;
                    case "down": depth += distance; break;
                }
            }
            Console.WriteLine((forward * depth).ToString());
        }

        public static void Day2Part2Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day2", "Day2");

            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            foreach (var instruction in todaysInputData)
            {
                var direction = instruction.ToString().Substring(0, instruction.Length - 2);
                var distance = int.Parse(instruction.ToString().Substring(instruction.Length - 1, 1));

                switch (direction)
                {
                    case "forward":
                        {
                            horizontalPosition += distance; 
                            depth += (aim * distance);  
                            break;
                        }
                    case  "up": 
                        {
                            aim -= distance;
                            break;
                        }
                    case "down":
                        {  
                            aim += distance;
                            break;
                        }
                }
            }
            Console.WriteLine((horizontalPosition * depth).ToString());
        }
    }
}
