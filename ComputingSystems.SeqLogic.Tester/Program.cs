using System;
using ComputingSystems.Core;

namespace ComputingSystems.SeqLogic.Tester
{
    class Program
    {
        private static Ram16k _ram;
        static void Main(string[] args)
        {
            _ram = new Ram16k();
            _ram.Address.AttachInput("00 000 000 000 000".ToBinary().ToBus());
            _ram.Clock = false;
            ReadAndLogAll();
            Write("10 000 000 000 000", "1010101010101010".ToBinary());
            ReadAndLogAll();
            Write("10 100 000 010 100", "0101 0101 0101 0101".ToBinary());
            ReadAndLogAll();
            ReadAndLog("10 100 000 010 100");
            Console.ReadLine();
        }

        private static void ReadAndLog(string address)
        {
            Console.WriteLine(Read(address).ToBinaryString());
        }

        private static void ReadAndLogAll()
        {
            var addresses = new[]
            {
                "10 000 000 000 000",
                "10 000 000 000 001",
                "10 000 000 000 010",
                "10 000 000 000 011",
                "10 000 000 000 100",
                "10 000 000 000 101",
                "10 000 000 000 110",
                "10 000 000 000 111"
            };
            var i = 0;
            foreach (var address in addresses)
            {
                Console.WriteLine($"{i}: {Read(address).ToBinaryString()}");
                i++;
            }

            Console.WriteLine();
        }

        private static bool[] Read(string address)
        {
            _ram.Address.AttachInput(address.ToBinary().ToBus());
            _ram.Load.AttachInput(false.ToPin());
            _ram.Clock = !_ram.Clock;
            return _ram.Output.ToBits();
        }

        private static void Write(string address, bool[] value)
        {
            _ram.Address.AttachInput(address.ToBinary().ToBus());
            _ram.Input.AttachInput(value.ToBus());
            _ram.Load.AttachInput(true.ToPin());
            _ram.Clock = !_ram.Clock;
        }
    }
}
