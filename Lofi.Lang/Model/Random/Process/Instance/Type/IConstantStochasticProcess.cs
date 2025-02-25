using Lofi.Lang.Model.Random.Variable;
using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Seq.Type;

namespace Lofi.Lang.Model.Random.Process.Instance.Type;

public interface IConstantStochasticProcess<out T>
    : IStochasticProcess<T>
    where T : notnull
{
    T Value { get; }

    ISeq<DateTime> IStochasticProcess<T>.Times
        => Seq.Empty<DateTime>();

    IRandomVariable<T> IStochasticProcess<T>.At(DateTime _)
        => Value.ToRandomVariable();
}