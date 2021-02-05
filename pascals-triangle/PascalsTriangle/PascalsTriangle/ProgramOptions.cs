using MatthiWare.CommandLine.Core.Attributes;

namespace PascalsTriangle
{
    public class ProgramOptions
    {
        [Required, Name("n", "number"), Description("Number of rows in the Pascal's Triangle")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Rows { get; set; }
    }
}