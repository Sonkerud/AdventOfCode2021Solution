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

            for (int i = 0; i < todaysInputData.Count(); i++)
            {
                var line = todaysInputData[i];
            
                List<string> openChunks = new List<string>();

                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");
                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");
                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");
                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");
                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");
                line = line.Replace("<>", "");
                line = line.Replace("()", "");
                line = line.Replace("{}", "");
                line = line.Replace("[]", "");


                if (line.Contains(">") || line.Contains("}") || line.Contains(")") || line.Contains("]"))
                {
                    Console.WriteLine(line);
                    string expected = "";
                    //line.ElementAt(line.First(x => x == '>' || x == '}' || x == ')' || x == ']').);
                    var expectedTurnIt = line.ElementAt(line.IndexOf(line.First(x => x == '>' || x == '}' || x == ')' || x == ']')));
                    if (expectedTurnIt == ']')
                    {
                       expected = "]";
                        results.Add(57);
                    }
                    if (expectedTurnIt == ')')
                    {
                        expected = ")";
                        results.Add(3);
                    }
                    if (expectedTurnIt == '>')
                    {
                        expected = ">";
                        results.Add(25137);
                    }
                    if (expectedTurnIt == '}')
                    {
                        expected = "}";
                        results.Add(1197);
                    }

                    Console.WriteLine(expected);

                }
               
            }
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
//Console.WriteLine("heh");
//Console.WriteLine($"Nr of ( = {line.Where(x => x.Equals('(')).ToList().Count()}");
//Console.WriteLine($"Nr of ) = {line.Where(x => x.Equals(')')).ToList().Count()}");
//Console.WriteLine($"Nr of x = {line.Where(x => x.Equals('{')).ToList().Count()}");
//Console.WriteLine($"Nr of x = {line.Where(x => x.Equals('}')).ToList().Count()}");
//Console.WriteLine($"Nr of [ = {line.Where(x => x.Equals('[')).ToList().Count()}");
//Console.WriteLine($"Nr of ] = {line.Where(x => x.Equals(']')).ToList().Count()}");
//Console.WriteLine($"Nr of < = {line.Where(x => x.Equals('<')).ToList().Count()}");
//Console.WriteLine($"Nr of > = {line.Where(x => x.Equals('>')).ToList().Count()}");

/* for (int y = 0; y < line.Length; y++)
 {

     var c = line[i];

     switch (c.ToString())
     {
         case "{":
             openChunks.Add(c.ToString());
             break;
         case "(":
             openChunks.Add(c.ToString());
             break;
         case "<":
             openChunks.Add(c.ToString());
             break;
         case "[":
             openChunks.Add(c.ToString());
             break;

         case "}":
             {
                 if (openChunks.Any(x => x == "{"))
                 {
                     openChunks.RemoveAt(openChunks.LastIndexOf("{"));
                 }
                 else
                 {
                     Console.WriteLine(c.ToString());
                 }
             }
             break;
         case ")":
             if (openChunks.Any(x => x == "("))
             {
                 openChunks.RemoveAt(openChunks.LastIndexOf("("));
             }
             else
             {
                 Console.WriteLine(c.ToString());
             }
             break;
         case ">":
             if (openChunks.Any(x => x == "<"))
             {
                 openChunks.RemoveAt(openChunks.LastIndexOf("<"));
             }
             else
             {
                 Console.WriteLine(c.ToString());
             }
             break;
         case "]":
             if (openChunks.Any(x => x == "["))
             {
                 openChunks.RemoveAt(openChunks.LastIndexOf("["));
             }
             else
             {
                 Console.WriteLine(c.ToString());
             }
             break;

     }
 }
*/