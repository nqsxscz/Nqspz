using Lofi.Prelude.Data.Instance.Maybe;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Trait;

public interface IObservable<TC>
    where TC : IObservable<TC>
{
    static abstract IMaybe<T> Observe<T>(
        ITypeConstructor<TC, T> observable,
        DateTime t)
        where T : notnull;
}