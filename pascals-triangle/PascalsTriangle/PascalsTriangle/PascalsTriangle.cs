using System;
using System.Collections.Generic;

namespace PascalsTriangle
{
    public static class PascalsTriangle
    {
        public static IEnumerable<List<int>> CalculatePascalsTriangle(int number)
        {
            var rows = new List<List<int>>();
            
            for (var i = 0; i < number; i++)
            {
                var row = new List<int>();

                switch (rows.Count)
                {
                    case 0:
                        row.Add(1);
                        break;
                    case 1:
                        row.Add(1);
                        row.Add(1);
                        break;
                    default:
                    {
                        row.Add(1);

                        for (var j = 0; j < rows[i - 1].Count; j++)
                        {
                            try
                            {
                                row.Add(rows[i - 1][j] + rows[i - 1][j + 1]);
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    
                        row.Add(1);
                        break;
                    }
                }
                
                rows.Add(row);
            }

            return rows;
        }

        public static void DisplayPascalsTriangle(IEnumerable<List<int>> pascalsTriangle)
        {
            foreach (var list in pascalsTriangle)
            {
                foreach (var number in list)
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}