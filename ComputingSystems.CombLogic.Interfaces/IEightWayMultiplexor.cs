﻿using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IEightWayMultiplexor
    {
        IPin[] Input { get; }
        IPin[] Selector { get; }
        IPin Output { get; }

        void Fill(IPin[] input, IPin[] selector);
    }
}