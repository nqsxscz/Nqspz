using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;

public interface IMaybe :
    IMonad<IMaybe>,
    ITraversable<IMaybe>
{
    static ITypeConstructor<IMaybe, T>
        IMonad<IMaybe>.MReturn<T>(T t)
        => Data.Maybe.Nothing<T>();

    static ITypeConstructor<IMaybe, T2>
        IMonad<IMaybe>.SelectMany<T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<IMaybe, T2>> selector)
        => maybe switch
        {
            IJust<T1> { Value: var x } =>
                selector(x),
            _ =>
                Data.Maybe.Nothing<T2>()
        };

    static T2 IFoldable<IMaybe>.AggregateRight<T1, T2>(
        ITypeConstructor<IMaybe, T1> maybe,
        T2 init,
        Func<T1, T2, T2> f)
        => maybe switch
        {
            IJust<T1> just =>
                f(just.Value, init),
            _ =>
                init
        };

    static ITypeConstructor<TF, ITypeConstructor<IMaybe, T2>>
        ITraversable<IMaybe>.Traverse<TF, T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<TF, T2>> f)
        => maybe switch
        {
            IJust<T1> { Value: var x } =>
                f(x).Select(Data.Maybe.Of),
            _ =>
                TF.Pure(Data.Maybe.Nothing<T2>())
        };
}