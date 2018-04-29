using System;
using System.Linq;
using System.Reflection;

namespace ComputingSystems.CombLogic.Tester
{
    class Program
    {
        private static readonly string[] TypesToTest = {nameof(Nand), nameof(Not), nameof(And), nameof(Or), nameof(Xor), nameof(Multiplexor), nameof(Demultiplexor)};

        static void Main(string[] args)
        {
            var implTypes = typeof(Nand).GetTypeInfo().Assembly.GetExportedTypes();
            var refTypes = typeof(ReferenceImplementations.Nand).GetTypeInfo().Assembly.GetExportedTypes();
            foreach (var type in TypesToTest)
            {
                Console.WriteLine("------");
                Console.WriteLine(type);
                var implType = implTypes.Single(t => t.Name == type);
                var refType = refTypes.Single(t => t.Name == type);
                var implGate = Activator.CreateInstance(implType);
                var refGate = Activator.CreateInstance(refType);
                if (implGate is ISingleOutputGate singleOutputImpl && refGate is ISingleOutputGate singleOutputRef)
                {
                    Console.WriteLine("REFERENCE:");
                    SingleOutputTester.Test(singleOutputRef);
                    Console.WriteLine("IMPLEMENTATION:");
                    SingleOutputTester.Test(singleOutputImpl);
                    continue;
                }
                if (implGate is ITwoOutputGate twoOutputImpl && refGate is ITwoOutputGate twoOutputRef)
                {
                    Console.WriteLine("REFERENCE:");
                    TwoOutputTester.Test(twoOutputRef);
                    Console.WriteLine("IMPLEMENTATION:");
                    TwoOutputTester.Test(twoOutputImpl);
                    continue;
                }
                throw new NotImplementedException();
            }
            Console.ReadLine();
        }
    }

    public static class TwoOutputTester
    {
        public static void Test(ITwoOutputGate gate)
        {
            if (gate is TwoInputGate twoInputGate)
            {
                TestInput(twoInputGate, false, false);
                TestInput(twoInputGate, false, true);
                TestInput(twoInputGate, true, false);
                TestInput(twoInputGate, true, true);
            }
        }

        private static void TestInput(TwoInputGate gate, bool input1, bool input2)
        {
            gate.Fill(input1, input2);
            var outGate = (ITwoOutputGate) gate;
            Console.WriteLine($"{input1.Bit()} {input2.Bit()}: {outGate.Output1.Bit()} {outGate.Output2.Bit()}");
        }
    }

    public static class SingleOutputTester
    {
        public static void Test(ISingleOutputGate gate)
        {
            if (gate is SingleInputGate singleInputGate)
            {
                TestInput(singleInputGate, false);
                TestInput(singleInputGate, true);
                return;
            }
            if (gate is TwoInputGate twoInputGate)
            {
                TestInput(twoInputGate, false, false);
                TestInput(twoInputGate, false, true);
                TestInput(twoInputGate, true, false);
                TestInput(twoInputGate, true, true);
                return;
            }
            if (gate is ThreeInputGate threeInputGate)
            {
                TestInput(threeInputGate, false, false, false);
                TestInput(threeInputGate, false, false, true);
                TestInput(threeInputGate, false, true, false);
                TestInput(threeInputGate, false, true, true);

                TestInput(threeInputGate, true, false, false);
                TestInput(threeInputGate, true, false, true);
                TestInput(threeInputGate, true, true, false);
                TestInput(threeInputGate, true, true, true);
            }
        }

        private static void TestInput(SingleInputGate gate, bool input)
        {
            gate.Fill(input);
            Console.WriteLine($"{input.Bit()}: {((ISingleOutputGate)gate).Output.Bit()}");
        }

        private static void TestInput(TwoInputGate gate, bool input1, bool input2)
        {
            gate.Fill(input1, input2);
            Console.WriteLine($"{input1.Bit()} {input2.Bit()}: {((ISingleOutputGate)gate).Output.Bit()}");
        }

        private static void TestInput(ThreeInputGate gate, bool input1, bool input2, bool input3)
        {
            gate.Fill(input1, input2, input3);
            Console.WriteLine($"{input1.Bit()} {input2.Bit()} {input3.Bit()}: {((ISingleOutputGate)gate).Output.Bit()}");
        }
    }

    public static class BoolExtensions
    {
        public static int Bit(this bool input)
        {
            return input ? 1 : 0;
        }
    }
}