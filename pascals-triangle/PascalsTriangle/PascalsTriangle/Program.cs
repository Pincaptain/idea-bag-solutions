using System;
using MatthiWare.CommandLine;

namespace PascalsTriangle
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var options = new CommandLineParserOptions()
            {
                AppName = "Pascal's Triangle"
            };
            var parser = new CommandLineParser<ProgramOptions>(options);
            var result = parser.Parse(args);

            if (result.HasErrors)
            {
                Console.Error.WriteLine("Invalid program arguments provided");
                
                return;
            }

            var programOptions = result.Result;
            var rows = programOptions.Rows;
            
            PascalsTriangle.DisplayPascalsTriangle(PascalsTriangle.CalculatePascalsTriangle(rows));
        }
    }
}