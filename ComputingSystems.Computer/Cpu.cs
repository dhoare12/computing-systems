using System;
using System.Linq;
using System.Runtime.CompilerServices;
using ComputingSystems.BoolArith.ReferenceImplementation;
using ComputingSystems.CombLogic.ReferenceImplementations;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.Interfaces;
using ComputingSystems.SeqLogic.ReferenceImplementation;

namespace ComputingSystems.Computer
{
    public class Cpu : IClockedComponent
    {
        public Cpu()
        {
            Pc.Inc.AttachInput(new ValuePin(true));
        }
        public CpuInputs Inputs { get; set; }

        private readonly CpuOutputs _outputsInner = new CpuOutputs();

        public CpuOutputs Outputs => _outputsInner;

        public readonly SixteenBitRegister D = new SixteenBitRegister();
        public readonly SixteenBitRegister A = new SixteenBitRegister();

        public readonly NBitCounter Pc = new NBitCounter(15);

        private readonly SixteenBitMultiplexor _aluSecondInput = new SixteenBitMultiplexor();

        private readonly Not _isAInstruction = new Not();
        private readonly SixteenBitMultiplexor _aRegisterInput = new SixteenBitMultiplexor();
        private readonly Or _shouldUpdateARegister = new Or();

        private readonly And _shouldUpdateDRegister = new And();

        private readonly And _shouldWriteMem = new And();

        private readonly Not _outNotZero = new Not();
        private readonly Not _outNotNeg = new Not();
        private readonly And _outPos = new And();
        private readonly And _negativeJumpCondition = new And();
        private readonly And _zeroJumpCondition = new And();
        private readonly And _positiveJumpCondition = new And();
        private readonly Or _shouldJumpInner1 = new Or();
        private readonly Or _shouldJumpInner2 = new Or();
        private readonly And _shouldJump = new And();

        private readonly Alu _alu = new Alu();

        public void Refresh()
        {
            var isCInstruction = Inputs.Instruction.Pins[0];

            _isAInstruction.Input.AttachInput(isCInstruction);

            // a instruction handling
            var aInstructionAInput = new Bus(Inputs.Instruction.Pins.Skip(1).Take(15).ToArray());


            // c instruction handling
            var computationInstruction = Inputs.Instruction.Pins.Skip(3).Take(7).ToArray();

            _aluSecondInput.Fill(A.Output, Inputs.InM, computationInstruction[0]);

            _alu.Fill(computationInstruction[1], computationInstruction[2], computationInstruction[3],
                computationInstruction[4], computationInstruction[5], computationInstruction[6], D.Output,
                _aluSecondInput.Output);

            var destinationInstruction = Inputs.Instruction.Pins.Skip(10).Take(3).ToArray();

            var cInstructionAInput = _alu.Out;
            D.Input.AttachInput(_alu.Out);
            _outputsInner.OutM.AttachInput(_alu.Out);

            _shouldUpdateARegister.Fill(destinationInstruction[0], _isAInstruction.Output);
            A.Load.AttachInput(_shouldUpdateARegister.Output);
            _aRegisterInput.Fill(aInstructionAInput, cInstructionAInput, isCInstruction);
            A.Input.AttachInput(_aRegisterInput.Output);
            
            _shouldUpdateDRegister.Fill(destinationInstruction[1], isCInstruction);
            D.Load.AttachInput(_shouldUpdateDRegister.Output);

            _shouldWriteMem.Fill(destinationInstruction[2], isCInstruction);
            _outputsInner.WriteM.AttachInput(_shouldWriteMem.Output);
            _outputsInner.AddressM.AttachInput(A.Output);

            // Jump handling

            var jumpInstruction = Inputs.Instruction.Pins.Skip(13).Take(3).ToArray();

            var outNeg = _alu.Ng;
            var outZero = _alu.Zr;
            _outNotNeg.Input.AttachInput(outNeg);
            _outNotZero.Input.AttachInput(outZero);
            _outPos.Fill(_outNotNeg.Output, _outNotZero.Output);
            var outPos = _outPos.Output;

            _negativeJumpCondition.Fill(jumpInstruction[0], outNeg);
            _zeroJumpCondition.Fill(jumpInstruction[1], outNeg);
            _positiveJumpCondition.Fill(jumpInstruction[2], outPos);

            _shouldJumpInner1.Fill(_negativeJumpCondition.Output, _zeroJumpCondition.Output);
            _shouldJumpInner2.Fill(_shouldJumpInner1.Output, _positiveJumpCondition.Output);
            _shouldJump.Fill(_shouldJumpInner2.Output, isCInstruction);

            Pc.Load.AttachInput(_shouldJump.Output);
            
            Pc.In.AttachInput(A.Output);

            // TODO: Jump logic

            _outputsInner.Pc.AttachInput(Pc.Out);
        }

        public bool Clock
        {
            get => throw new NotImplementedException();
            set
            {
                Pc.Clock = value;
                A.Clock = value;
                D.Clock = value;
            }
        }
    }

    public class CpuInputs
    {
        // From data memory
        public IBus InM { get; } = new Bus(16);

        // From instruction memory
        public IBus Instruction { get; }= new Bus(15);
        
        public IPin Reset { get; }= new Pin();
    }

    public class CpuOutputs
    {
        // To data memory
        public IBus OutM { get; }= new Bus(16);
        public IPin WriteM { get; }= new Pin();
        public IBus AddressM { get;  }= new Bus(15);
        // To instruction memory
        public IBus Pc { get; }= new Bus(15);
    }
}
