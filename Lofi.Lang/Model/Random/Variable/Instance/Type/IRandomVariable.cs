using Lofi.Lang.Model.Random.Variable.Instance.TypeConstructor;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Type;

public interface IRandomVariable<out T>
    : ITypeConstructor<IRandomVariable, T>
    where T : notnull
{
    ISeq<T> Sample();
}