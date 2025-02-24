using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface ISelectProcess<T1, out T2>
    : IProcess<T2>
    where T1 : notnull
    where T2 : notnull
{
    IProcess<T1> Operand { get; }

    Func<T1, T2> Selector { get; }

    IMaybe<T2> IProcess<T2>.Observe(DateTime t)
        => Operand
            .Observe(t)
            .Select(Selector)
            .ToMaybe();
}