using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day10

    {
        public static void Day10Part1Calculator()
        {
            var todaysInputData = AdventOfCode2021.Inputreader.ReadTxtString("Day10", "Day10");
            List<int> results = new List<int>();
            List<long> resultsPart2 = new List<long>();
            List<string> completion = new List<string>();

            for (int i = 0; i < todaysInputData.Count(); i++)
            {
                var line = todaysInputData[i];
                var tempLine = todaysInputData[i];
                List<string> openChunks = new List<string>();

                while (line.Contains("<>") || line.Contains("{}") || line.Contains("()") || line.Contains("[]"))
                {
                    line = line.Replace("<>", "");
                    line = line.Replace("()", "");
                    line = line.Replace("{}", "");
                    line = line.Replace("[]", "");
                }

                if (line.Contains(">") || line.Contains("}") || line.Contains(")") || line.Contains("]"))
                {
                    var expectedTurnIt = line.ElementAt(line.IndexOf(line.First(x => x == '>' || x == '}' || x == ')' || x == ']')));
                    if (expectedTurnIt == ']')
                    {
                        results.Add(57);
                    }
                    if (expectedTurnIt == ')')
                    {
                        results.Add(3);
                    }
                    if (expectedTurnIt == '>')
                    {
                        results.Add(25137);
                    }
                    if (expectedTurnIt == '}')
                    {
                        results.Add(1197);
                    }
                }
                else
                {
                    completion = line.Reverse().ToList().Select(x => x.ToString()).ToList();
                    long score = 0;

                    for (int l = 0; l < completion.Count(); l++)
                    {
                        score = score * 5;
                        switch (completion[l])
                        {
                            case "(": score += 1; break;
                            case "[": score += 2; break;
                            case "{": score += 3; break;
                            case "<": score += 4; break;
                        }
                    }
                    resultsPart2.Add(score);
                }
            }
            //Part 2
            var part2 = resultsPart2.OrderBy(x => x).ToList();
            Console.WriteLine(resultsPart2.OrderBy(x => x).ElementAt((resultsPart2.Count() / 2)));

            // Part 1
            var resultsGrouped = results.GroupBy(x => x).ToList();
            int output = 0;
            for (int p = 0; p < resultsGrouped.Count; p++)
            {
                output += resultsGrouped[p].Count() * resultsGrouped[p].Key;
            }
            Console.WriteLine(output);
        }
    }
}
