using Lofi.Prelude.Control;
using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Data.Control.Instance.Maybe.Type;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Data.Control.Instance.Maybe.TypeConstructor;

public interface IMaybe :
    IMonad<IMaybe>,
    ITraversable<IMaybe>
{
    static ITypeConstructor<IMaybe, T>
        IMonad<IMaybe>.Return<T>(T t)
        => t.ToMaybe();

    static ITypeConstructor<IMaybe, T2>
        IMonad<IMaybe>.SelectMany<T1, T2>(
            ITypeConstructor<IMaybe, T1> operand,
            Func<T1, ITypeConstructor<IMaybe, T2>> selector)
        => operand switch
        {
            IJust<T1> { Value: var x } =>
                selector(x),
            _ =>
                Control.Maybe.Nothing<T2>()
        };
    
    static ITypeConstructor<IMaybe, T3>
        IApplicative<IMaybe>.Lift<T1, T2, T3>(
            ITypeConstructor<IMaybe, T1> left,
            ITypeConstructor<IMaybe, T2> right,
            Func<T1, T2, T3> combinator)
        => left
            .LiftM(
                right, 
                combinator);

    static T2 IFoldable<IMaybe>.AggregateRight<T1, T2>(
        ITypeConstructor<IMaybe, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        => operand switch
        {
            IJust<T1> just =>
                accumulator(just.Value, init),
            _ =>
                init
        };

    static ITypeConstructor<TF, ITypeConstructor<IMaybe, T2>>
        ITraversable<IMaybe>.Traverse<TF, T1, T2>(
            ITypeConstructor<IMaybe, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> traverse)
        => operand switch
        {
            IJust<T1> { Value: var x } =>
                traverse(x)
                    .Select(Control.Maybe.Of),
            _ =>
                TF.Pure(
                    Control.Maybe.Nothing<T2>())
        };
}