using System;
using System.Linq;
using ComputingSystems.Core;
using ComputingSystems.SeqLogic.ReferenceImplementation;

namespace ComputingSystems.Computer
{
    public class Computer
    {
        private bool _clock;

        public Computer(bool[][] instructions)
        {
            _rom.Preload(instructions);
        }

        private readonly Cpu _cpu = new Cpu
        {
            Inputs = new CpuInputs()
        };

        private readonly Ram16k _rom = new Ram16k();
        private readonly Ram16k _dataMemory = new Ram16k();

        public void ClockTick()
        {
            _clock = !_clock;

            _dataMemory.Clock = _clock;
            _rom.Clock = _clock;
            _cpu.Clock = _clock;

            _cpu.Inputs.Instruction.AttachInput(_rom.Output);
            _cpu.Inputs.InM.AttachInput(_dataMemory.Output);
            _cpu.Inputs.Reset.AttachInput(new ValuePin(false)); // TODO

            

            var cpuOutputs = _cpu.Outputs;

            _rom.Address.AttachInput(cpuOutputs.Pc);

            _dataMemory.Address.AttachInput(cpuOutputs.AddressM);
            _dataMemory.Input.AttachInput(cpuOutputs.OutM);
            _dataMemory.Load.AttachInput(cpuOutputs.WriteM);

            _cpu.Refresh();
        }

        public int GetDataValue(int address)
        {
            return _dataMemory.GetDataValue(address);
        }

        public void SetDataValue(int address, int val)
        {
            _dataMemory.SetDataValue(address, val);
        }

        public int ProgramCounter => BinaryUtils.BitsToInt(_cpu.Outputs.Pc.ToBits(), 15);

        public int A => BinaryUtils.BitsToInt(_cpu.A.Output.ToBits(), 16);

        public int D => BinaryUtils.BitsToInt(_cpu.D.Output.ToBits(), 16);

        public string CurrentInstruction => CurrentInstructionBits.ToBinaryString();

        public bool[] CurrentInstructionBits => _cpu.Inputs.Instruction.ToBits();
    }
}
