using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface IMonad<TC>
    : IApplicative<TC>
    where TC : IMonad<TC>
{
    static abstract ITypeConstructor<TC, T> Return<T>(T t)
        where T : notnull;

    static abstract ITypeConstructor<TC, T2> SelectMany<T1, T2>(
        ITypeConstructor<TC, T1> operand,
        Func<T1, ITypeConstructor<TC, T2>> selector)
        where T1 : notnull
        where T2 : notnull;
    
    static virtual ITypeConstructor<TC, T3> LiftM<T1, T2, T3>(
        ITypeConstructor<TC, T1> left,
        ITypeConstructor<TC, T2> right,
        Func<T1, T2, T3> combinator)
        => from t1 in left 
           from t2 in right
           select combinator(t1, t2);
    
    static ITypeConstructor<TC, T2> IFunctor<TC>.Select<T1, T2>(
        ITypeConstructor<TC, T1> operand,
        Func<T1, T2> selector)
        => operand.SelectMany(
            t1 => TC.Return(selector(t1)));

    static ITypeConstructor<TC, T> IApplicative<TC>.Pure<T>(T t)
        => TC.Return(t);
}