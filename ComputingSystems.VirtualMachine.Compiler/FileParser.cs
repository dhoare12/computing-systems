using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingSystems.VirtualMachine.Compiler
{
    public struct ParsedLine
    {
        public string Command;
        public List<string> Args;

        public override string ToString() => (Command + " " + string.Join(" ", Args)).Trim();
    }

    public class FileParser
    {
        public IEnumerable<ParsedLine> Parse(List<string> lines)
        {
            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();
                
                if (line.StartsWith("//"))
                {
                    continue;
                }

                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!parts.Any())
                {
                    continue;
                }

                var command = parts[0];

                var commentPart = parts.FirstOrDefault(p => p.StartsWith("//"));

                var commandArgs = commentPart == null ? parts.Skip(1).ToList() : parts.Skip(1).Take(Array.IndexOf(parts, commentPart) - 1).ToList();

                yield return new ParsedLine
                {
                    Command = command,
                    Args = commandArgs
                };
            }
        }
    }
}
