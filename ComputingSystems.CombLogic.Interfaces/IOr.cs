﻿using ComputingSystems.Core;

namespace ComputingSystems.CombLogic.Interfaces
{
    public interface IOr
    {
        IPin Input1 { get; }
        IPin Input2 { get; }
        IPin Output { get; }
        void Fill(IPin input1, IPin input2);
    }
}