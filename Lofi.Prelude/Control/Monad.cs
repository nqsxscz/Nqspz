using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control;

public static class Monad
{
    public static ITypeConstructor<TC, T2> 
        SelectMany<TC, T1, T2>(this
            ITypeConstructor<TC, T1> operand,
            Func<T1, ITypeConstructor<TC, T2>> selector)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        => TC.SelectMany(operand, selector);
    
    public static ITypeConstructor<TC, T3> 
        SelectMany<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> operand,
            Func<T1, ITypeConstructor<TC, T2>> selector,
            Func<T1, T2, T3> combinator)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => operand.SelectMany(t1 =>
            selector(t1)
                .Select(t2 => 
                    combinator(t1, t2)));

    public static ITypeConstructor<TC, T> Flatten<TC, T>(
        this ITypeConstructor<TC, ITypeConstructor<TC, T>> operand)
        where TC : IMonad<TC>
        where T : notnull
        => operand.SelectMany(x => x);
    
    public static ITypeConstructor<TC, T3> 
        LiftM<TC, T1, T2, T3>(this 
            ITypeConstructor<TC, T1> left, 
            ITypeConstructor<TC, T2> right,
            Func<T1, T2, T3> combinator)
        where TC : IMonad<TC>
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => TC.LiftM(
            left, 
            right, 
            combinator);
}