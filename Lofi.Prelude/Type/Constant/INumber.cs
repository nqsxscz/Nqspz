namespace Lofi.Prelude.Type.Constant;

public interface INumber<T>
    where T : INumber<T>
{
    static abstract int Number { get; }
}