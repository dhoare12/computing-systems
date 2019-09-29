using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputingSystems.Core
{
    public interface IPin
    {
        bool Value { get; }
        void AttachInput(IPin pin);
    }

    public interface IBus
    {
        IPin[] Pins { get; }
        int Width { get; }
        void AttachInput(IBus bus);
    }

    public class Bus : IBus
    {
        public Bus(IPin[] pins)
        {
            Width = pins.Length;
            Pins = pins;
        }

        public Bus(int width)
        {
            Width = width;
            Pins = Enumerable.Range(0, width).Select(_ => new Pin()).ToArray();
        }

        public IPin[] Pins { get; }
        public int Width { get; }
        public void AttachInput(IBus bus)
        {
            if (bus.Width != Width)
            {
                throw new Exception("Bus width mismatch");
            }

            for (var i = 0; i < Width; i++)
            {
                Pins[i].AttachInput(bus.Pins[i]);
            }
        }
    }

    public class ValueBus : IBus
    {
        public ValueBus(int width, Func<int, bool> func)
        {
            Width = width;
            Pins = Enumerable.Range(0, width).Select(i => new ValuePin(() => func(i))).ToArray();
        }

        public ValueBus(int width, bool[] values)
        {
            Width = width;
            Pins = Enumerable.Range(0, width).Select(i => new ValuePin(() => values[i])).ToArray();
        }

        public IPin[] Pins { get; }
        public int Width { get; }
        public void AttachInput(IBus bus)
        {
            throw new NotSupportedException("Cannot attach input to a value bus");
        }
    }

    public class ValuePin : IPin
    {
        private readonly Func<bool> _func;

        public ValuePin(Func<bool> func)
        {
            _func = func;
        }

        public bool Value => _func();
        
        public void AttachInput(IPin pin)
        {
            throw new NotSupportedException("Cannot attach input to a value pin");
        }
    }

    public class Pin : IPin
    {
        public Pin()
        {
            
        }

        public Pin(IPin attachedTo)
        {
            _attachedTo = attachedTo;
        }

        public bool Value => _attachedTo.Value;

        public void AttachInput(IPin pin) => _attachedTo = pin;
        
        private IPin _attachedTo;

        public static Pin[] Array(int length) => Enumerable.Range(0, length).Select(_ => new Pin()).ToArray();
    }
}
