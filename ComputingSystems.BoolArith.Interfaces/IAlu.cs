namespace ComputingSystems.BoolArith.Interfaces
{
    public interface IAlu
    {
        bool F { get; set; }
        bool No { get; set; }
        bool Nx { get; set; }
        bool Ny { get; set; }
        bool[] X { get; set; }
        bool[] Y { get; set; }
        bool Zx { get; set; }
        bool Zy { get; set; }

        bool Ng { get; }
        bool Zr { get; }
        bool[] Out { get; }

        void Fill(bool zx, bool nx, bool zy, bool ny, bool f, bool no, bool[] x, bool[] y);
    }
}
