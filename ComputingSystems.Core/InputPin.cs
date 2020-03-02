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

        bool[] ToBits();
        IBus Splice(int i);
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
                throw new Exception($"Bus width mismatch - attaching {bus.Width}-bus to {Width}-bus");
            }

            for (var i = 0; i < Width; i++)
            {
                Pins[i].AttachInput(bus.Pins[i]);
            }
        }

        public bool[] ToBits() => Pins.Select(x => x.Value).ToArray();

        public IBus Splice(int i) => new Bus(Pins.Take(i).ToArray());

        public IBus Pad(int i) => new Bus(Pins.Concat(Enumerable.Range(0, i - Width).Select(_ => false.ToPin())).ToArray());
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

        public bool[] ToBits() => Pins.Select(x => x.Value).ToArray();

        public IBus Splice(int i) => new Bus(Pins.Take(i).ToArray());
    }

    public class ValuePin : IPin
    {
        private readonly Func<bool> _func;

        public ValuePin(Func<bool> func)
        {
            _func = func;
        }

        public ValuePin(bool constant)
        {
            _func = () => constant;
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

        public bool Value => _attachedTo?.Value ?? throw new Exception("No input has been attached to this Pin");

        public void AttachInput(IPin pin) => _attachedTo = pin;
        
        private IPin _attachedTo;

        public static Pin[] Array(int length) => Enumerable.Range(0, length).Select(_ => new Pin()).ToArray();
    }
}
