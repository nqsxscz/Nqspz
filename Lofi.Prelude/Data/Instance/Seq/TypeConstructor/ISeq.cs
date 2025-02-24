using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Instance.Seq.TypeConstructor;

/// <summary>
/// </summary>
public interface ISeq :
    IMonad<ISeq>,
    ITraversable<ISeq>
{
    /// <summary>
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<ISeq, T>
        IMonad<ISeq>.MReturn<T>(T item)
    {
        return Data.Seq.Of(item);
    }

    /// <summary>
    /// </summary>
    /// <param name="seq"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<ISeq, T2>
        IMonad<ISeq>.SelectMany<T1, T2>(
            ITypeConstructor<ISeq, T1> seq,
            Func<T1, ITypeConstructor<ISeq, T2>> selector)
    {
        return seq.ToSeq()
            .Enumerable
            .SelectMany(t1 =>
                selector(t1)
                    .ToSeq()
                    .Enumerable)
            .ToSeq();
    }

    /// <summary>
    /// </summary>
    /// <param name="seq"></param>
    /// <param name="init"></param>
    /// <param name="aggregator"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static T2 IFoldable<ISeq>.AggregateRight<T1, T2>(
        ITypeConstructor<ISeq, T1> seq,
        T2 init,
        Func<T1, T2, T2> aggregator)
    {
        return seq.ToSeq()
            .Aggregate(
                init,
                aggregator.Flip());
    }

    /// <summary>
    /// </summary>
    /// <param name="seq"></param>
    /// <param name="f"></param>
    /// <typeparam name="TF"></typeparam>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static ITypeConstructor<TF, ITypeConstructor<ISeq, T2>>
        ITraversable<ISeq>.Traverse<TF, T1, T2>(
            ITypeConstructor<ISeq, T1> seq,
            Func<T1, ITypeConstructor<TF, T2>> f)
    {
        return seq.AggregateRight(
            TF.Pure(Data.Seq.Empty<T2>()),
            (x, ys) =>
                TF.Lift(
                    ys,
                    f(x),
                    Data.Seq.Append));
    }
}