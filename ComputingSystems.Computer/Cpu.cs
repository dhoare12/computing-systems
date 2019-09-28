using System;
using System.Linq;
using ComputingSystems.BoolArith.ReferenceImplementation;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.SeqLogic.ReferenceImplementation;

namespace ComputingSystems.Computer
{
    public class Cpu
    {
        public CpuInputs Inputs { get; set; }
        public CpuOutputs Outputs { get; set; }

        private SixteenBitRegister D { get; set; }
        private SixteenBitRegister A { get; set; }

        private readonly SixteenBitMultiplexor _aluSecondInput = new SixteenBitMultiplexor();
        private readonly Not _isAInstruction = new Not();
        private readonly Or _shouldUpdateARegister = new Or();
        private readonly And _shouldUpdateDRegister = new And();
        private readonly And _shouldWriteMem = new And();

        private readonly Alu _alu = new Alu();

        public void Refresh()
        {
            var isCInstruction = Inputs.Instruction[15];

            _isAInstruction.Input = isCInstruction;

            // a instruction handling
            A.Input = Inputs.Instruction.Take(15).ToArray();

            // c instruction handling
            var computationInstruction = Inputs.Instruction.Skip(6).Take(7).ToArray();
            _aluSecondInput.Fill(A.Output, Inputs.InM, computationInstruction[6]);

            _alu.Fill(computationInstruction[5], computationInstruction[4], computationInstruction[3],
                computationInstruction[2], computationInstruction[1], computationInstruction[0], D.Output,
                _aluSecondInput.Output);

            var destinationInstruction = Inputs.Instruction.Skip(3).Take(3).ToArray();

            A.Input = _alu.Out;
            D.Input = _alu.Out;
            Outputs.OutM = _alu.Out;

            _shouldUpdateARegister.Fill(destinationInstruction[2], _isAInstruction.Output);
            A.Load = _shouldUpdateARegister.Output;
            
            _shouldUpdateDRegister.Fill(destinationInstruction[1], isCInstruction);
            D.Load = _shouldUpdateDRegister.Output;

            _shouldWriteMem.Fill(destinationInstruction[0], isCInstruction);
            Outputs.WriteM = _shouldWriteMem.Output;
        }
    }

    public class CpuInputs
    {
        // From data memory
        public bool[] InM { get; set; }

        // From instruction memory
        public bool[] Instruction { get; set; }
        
        public bool Reset { get; set; }
    }

    public class CpuOutputs
    {
        // To data memory
        public bool[] OutM { get; set; }
        public bool WriteM { get; set; }
        public bool[] AddressM { get; set; }
        // To instruction memory
        public bool[] Pc { get; set; }
    }
}
