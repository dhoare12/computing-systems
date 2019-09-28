using System;
using System.Collections.Generic;
using System.Text;
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
            Inputs = new CpuInputs(),
            Outputs = new CpuOutputs()
        };

        private readonly Ram16k _rom = new Ram16k();
        private readonly Ram16k _dataMemory = new Ram16k();

        public void ClockTick()
        {
            _cpu.Inputs.Instruction = _rom.Output;
            _cpu.Inputs.InM = _dataMemory.Output;
            _cpu.Inputs.Reset = false; // TODO
            _cpu.Refresh();

            _rom.Address = _cpu.Outputs.Pc;

            _dataMemory.Address = _cpu.Outputs.AddressM;
            _dataMemory.Input = _cpu.Outputs.OutM;
            _dataMemory.Load = _cpu.Outputs.WriteM;

            _clock = !_clock;

            _dataMemory.Clock = _clock;
            _rom.Clock = _clock;
            _cpu.Clock = _clock;
        }
    }
}
