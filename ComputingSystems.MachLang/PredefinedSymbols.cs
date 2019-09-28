using System.Collections.Generic;

namespace ComputingSystems.MachLang
{
    public class PredefinedSymbols
    {
        public static Dictionary<string, int> GetSymbols()
        {
            var symbols = new Dictionary<string, int>
            {
                ["SP"] = 0,
                ["LCL"]= 1,
                ["ARG"] = 2,
                ["THIS"] = 3,
                ["THAT"] = 4,
                ["SCREEN"] = 16384,
                ["KBD"] = 24576
            };

            for (var i = 0; i < 16; i++)
            {
                symbols[$"R{i}"] = i;
            }

            return symbols;
        } 
    }
}