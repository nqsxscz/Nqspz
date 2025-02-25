using Lofi.Lang.Model.Random.Process.Instance.TypeConstructor;
using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Process.Instance.Type;

public interface IStochasticProcess<out T>
    : ITypeConstructor<IStochasticProcess, T>
    where T : notnull
{
    ISeq<DateTime> Times { get; }
    
    IRandomVariable<T> At(DateTime t);
}