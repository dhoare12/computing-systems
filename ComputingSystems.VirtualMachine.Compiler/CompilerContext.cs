namespace ComputingSystems.VirtualMachine.Compiler
{
    public class CompilerContext
    {
        public CompilerContext(string fileName)
        {
            FileName = fileName;
        }

        public int EqualityLabelsUsed { get; set; }
        public int FunctionReturnLabelsUsed { get; set; }
        public string FileName { get; set; }
        public string FunctionName { get; set; }
    }
}
