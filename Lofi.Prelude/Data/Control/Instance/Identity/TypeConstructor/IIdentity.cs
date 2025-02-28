using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Identity.TypeConstructor;

public interface IIdentity :
    IMonad<IIdentity>,
    ITraversable<IIdentity>
{
    static ITypeConstructor<IIdentity, T>
        IMonad<IIdentity>.Return<T>(T t)
        => t.ToIdentity();

    static ITypeConstructor<IIdentity, T2>
        IMonad<IIdentity>.SelectMany<T1, T2>(
            ITypeConstructor<IIdentity, T1> operand,
            Func<T1, ITypeConstructor<IIdentity, T2>> selector)
        => selector(
            operand
                .ToIdentity()
                .Value);

    static T2 IFoldable<IIdentity>.AggregateRight<T1, T2>(
        ITypeConstructor<IIdentity, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        => accumulator(
            operand
                .ToIdentity()
                .Value, 
            init);

    static ITypeConstructor<TF, ITypeConstructor<IIdentity, T2>>
        ITraversable<IIdentity>.Traverse<TF, T1, T2>(
            ITypeConstructor<IIdentity, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        => traverse(operand
                .ToIdentity()
                .Value)
            .Select(Control.Identity.Of);
}