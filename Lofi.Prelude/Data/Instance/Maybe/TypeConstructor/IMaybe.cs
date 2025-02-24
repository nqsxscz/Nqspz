using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;

/// <summary>
/// </summary>
public interface IMaybe :
    IMonad<IMaybe>,
    ITraversable<IMaybe>
{
    /// <summary>
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IMaybe, T>
        IMonad<IMaybe>.MReturn<T>(T t)
    {
        return Data.Maybe.Nothing<T>();
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<IMaybe, T2>
        IMonad<IMaybe>.SelectMany<T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<IMaybe, T2>> selector)
    {
        return maybe switch
        {
            IJust<T1> { Value: var x } =>
                selector(x),
            _ =>
                Data.Maybe.Nothing<T2>()
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="init"></param>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static T2 IFoldable<IMaybe>.AggregateRight<T1, T2>(
        ITypeConstructor<IMaybe, T1> maybe,
        T2 init,
        Func<T1, T2, T2> f)
    {
        return maybe switch
        {
            IJust<T1> just =>
                f(just.Value, init),
            _ =>
                init
        };
    }

    /// <summary>
    /// </summary>
    /// <param name="maybe"></param>
    /// <param name="f"></param>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TF, ITypeConstructor<IMaybe, T2>>
        ITraversable<IMaybe>.Traverse<TF, T1, T2>(
            ITypeConstructor<IMaybe, T1> maybe,
            Func<T1, ITypeConstructor<TF, T2>> f)
    {
        return maybe switch
        {
            IJust<T1> { Value: var x } =>
                f(x).Select(Data.Maybe.Of),
            _ =>
                TF.Pure(Data.Maybe.Nothing<T2>())
        };
    }
}