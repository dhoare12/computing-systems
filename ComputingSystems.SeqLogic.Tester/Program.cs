using System;
using System.Linq;

namespace ComputingSystems.SeqLogic.Tester
{
    class Program
    {
        private static NBitRegister _register;
        static void Main(string[] args)
        {
            _register = new NBitRegister(4);
            SetRegisterLoad(true);
            SetRegisterInput("1010");
            ClockTick(); // 1010
            ClockTick();
            SetRegisterLoad(false);
            ClockTick();
            SetRegisterInput("0101");
            ClockTick();
            SetRegisterLoad(true);
            ClockTick(); // 0101
            ClockTick();
            SetRegisterInput("1111");
            ClockTick(); // 1111
            SetRegisterLoad(false);
            ClockTick();
            SetRegisterInput("0000");
            ClockTick();
        }

        private static string RegisterOutput => string.Join("", _register.Outputs.Select(o => o ? "1" : "0").ToArray());

        private static void ClockTick()
        {
            _register.Clock = !_register.Clock;
        }

        private static void SetRegisterInput(string input)
        {
            _register.Inputs = input.ToCharArray().Select(c => c == '1').ToArray();
        }

        private static void SetRegisterLoad(bool input)
        {
            _register.Load = input;
        }

        private static void PrintRegisterOutput()
        {
            Console.WriteLine(RegisterOutput);
        }
    }
}
