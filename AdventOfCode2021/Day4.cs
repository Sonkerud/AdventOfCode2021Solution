using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day4
    {
        public static void Day4Part1Calculator()
        {
            var todaysInputDataBingoNumbers = Inputreader.ReadTxtString("Day4", "Day4")[0];
            var todaysInputDataBoards = Inputreader.ReadTxtString("Day4", "Day4").Skip(1).ToList();

            var boards = CreateBoards(todaysInputDataBoards);
            PlayBingo(boards, todaysInputDataBingoNumbers);
        }

        public static List<BoardSquare[,]> CreateBoards(List<string> boards)
        {
           
            var boardsWithOutLineBreak = boards.Where(x => x != "").Select(x => x.Replace("  "," ")).ToList();
            List<BoardSquare[,]> boardList = new List<BoardSquare[,]>();

            for (int i = 0; i < boardsWithOutLineBreak.Count; i+=5)
            {
                var board = new BoardSquare[5, 5];
                for (int y = 0; y < 5; y++)
                {
                    for (int p = 0; p < 5; p++)
                    {   
                        var boardSquare = new BoardSquare();
                        if (boardsWithOutLineBreak[i + y][0].ToString().Equals(" "))
                        {
                            var replaceSpace = boardsWithOutLineBreak[i + y].Substring(1);                           
                            boardsWithOutLineBreak[i + y] = replaceSpace;
                            boardSquare.Number = int.Parse(boardsWithOutLineBreak[i + y].Split(" ")[p]);
                            boardSquare.Hit = false;
                            board[y, p] = boardSquare;
                        }
                        else
                        {
                            boardSquare.Number = int.Parse(boardsWithOutLineBreak[i + y].Split(" ")[p]);
                            boardSquare.Hit = false;
                            board[y, p] = boardSquare;
                        }
                    }
                }
                boardList.Add(board);
            }
            return boardList;
        }

        public static void PlayBingo(List<BoardSquare[,]> boards, string bingoNumbers)
        {
            bool bingo = false;
            int number = 0;
            List<int> boardsWithBingo = new List<int>();
            while (number < bingoNumbers.Split(",").Length && !bingo)
            {
                int bingoNumber = int.Parse(bingoNumbers.Split(",")[number]);
                for (int p = 0; p < boards.Count; p++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            if (boards[p][i, y].Number == bingoNumber)
                            {
                                boards[p][i, y].Hit = true;
                            }
                        }
                    }
                }
                
                for (int p = 0; p < boards.Count; p++)
                {
                    List<int> allNumbersInCurrentBoard = new List<int>();
                    List<int> hitNumbersInCurrentBoard = new List<int>();
                    
                    for (int i = 0; i < 5; i++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            allNumbersInCurrentBoard.Add(boards[p][i, y].Number);
                            if (boards[p][i, y].Hit)
                            {
                                hitNumbersInCurrentBoard.Add(boards[p][i, y].Number);
                            }
                        }
                        if (boards[p][i, 0].Hit
                         && boards[p][i, 1].Hit
                         && boards[p][i, 2].Hit
                         && boards[p][i, 3].Hit
                         && boards[p][i, 4].Hit
                         &! boardsWithBingo.Any(x => x == p))
                        {
                            var notHitNumbers = allNumbersInCurrentBoard.Except(hitNumbersInCurrentBoard).ToList();
                            int sum = notHitNumbers.Sum();
                            Console.WriteLine($"BoardNr: {p} NumberOfNumbers: {number} Sum: {sum} LastNumber: {bingoNumber} Answer: {sum * bingoNumber}");
                            boardsWithBingo.Add(p);
                            //bingo = true; 
                        }
                    }
                    for (int y = 0; y < 5; y++)
                    {
                        if (boards[p][0,y].Hit
                         && boards[p][1,y].Hit
                         && boards[p][2,y].Hit
                         && boards[p][3,y].Hit
                         && boards[p][4,y].Hit
                         &! boardsWithBingo.Any(x => x == p))
                        {
                            var notHitNumbers = allNumbersInCurrentBoard.Except(hitNumbersInCurrentBoard).ToList();
                            int sum = notHitNumbers.Sum();
                            boardsWithBingo.Add(p);
                            Console.WriteLine($"BoardNr: {p} NumberOfNumbers: {number} Sum: {sum} LastNumber: {bingoNumber} Answer: {sum * bingoNumber}");                           
                        }
                    }
                }
                 number++;
            }
        }
    }
}
