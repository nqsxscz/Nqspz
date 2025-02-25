using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface IConstantRandomVariable<out T>
    : IRandomVariable<T>
    where T : notnull
{
    T Value { get; }

    ISeq<T> IRandomVariable<T>.Sample()
        => Value.ToSeq();
}