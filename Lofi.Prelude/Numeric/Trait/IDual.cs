using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Numeric.Trait;

public interface IDual<T, TReal> : 
    IAdditiveGroup<T>,
    IMultiplicativeGroup<T>, 
    IRealFunctions<T>
    where T : IDual<T, TReal>
    where TReal : IReal<TReal>
{
    static abstract TReal Real(T t);

    static abstract TReal Dual(T t);

    static abstract T Of(
        TReal real, 
        TReal dual);
    
    static T IAdditiveSemigroup<T>.operator +(T left, T right)
        => T.Of(
            T.Real(left) + T.Real(right), 
            T.Dual(left) + T.Dual(right));
    
    static T IAdditiveMonoid<T>.Zero
        => T.Of(
            TReal.Zero, 
            TReal.Zero);
    
    static T IAdditiveGroup<T>.operator -(T left, T right)
        => T.Of(
            T.Real(left) - T.Real(right), 
            T.Dual(left) - T.Dual(right));
    
    static T IMultiplicativeSemigroup<T>.operator *(T left, T right)
        => T.Of(
            T.Real(left) * T.Real(right), 
            T.Dual(left) * T.Real(right) + T.Real(left) * T.Dual(right));
    
    static T IMultiplicativeMonoid<T>.One
        => T.Of(
            TReal.One, 
            TReal.Zero);
    
    static T IMultiplicativeGroup<T>.operator /(T left, T right)
        => T.Of(
            T.Real(left) / T.Real(right), 
            (T.Dual(left) * T.Real(right) - T.Real(left) * T.Dual(right)) / (T.Real(right) * T.Real(right)));
    
    static T IRealFunctions<T>.Pi
        => T.Of(TReal.Pi, TReal.Zero);
    
    static T IRealFunctions<T>.E
        => T.Of(TReal.E, TReal.Zero);
    
    static T IRealFunctions<T>.Sqrt(T t)
        => T.Of(
            TReal.Sqrt(T.Real(t)), 
            T.Dual(t) / ((TReal.One + TReal.One)*TReal.Sqrt(T.Real(t))));

    static T IRealFunctions<T>.Log(T t)
        => T.Of(
            TReal.Log(T.Real(t)),
            T.Dual(t) / T.Real(t));
    
    static T IRealFunctions<T>.Exp(T t)
        => T.Of(
            TReal.Exp(T.Real(t)),
            T.Dual(t) * TReal.Exp(T.Real(t)));

    static T IRealFunctions<T>.Sin(T t)
        => T.Of(
            TReal.Sin(T.Real(t)),
            T.Dual(t) * TReal.Cos(T.Real(t)));
    
    static T IRealFunctions<T>.Cos(T t)
        => T.Of(
            TReal.Cos(T.Real(t)),
            -T.Dual(t) * TReal.Sin(T.Real(t)));
    
    static T IRealFunctions<T>.Tan(T t)
        => T.Of(
            TReal.Tan(T.Real(t)),
            T.Dual(t) / (TReal.Cos(T.Real(t)) * TReal.Cos(T.Real(t))));
    
    static T IRealFunctions<T>.Asin(T t)
        => T.Of(
            TReal.Asin(T.Real(t)),
            T.Dual(t) / (TReal.One - T.Real(t)*T.Real(t)).Sqrt());
    
    static T IRealFunctions<T>.Acos(T t)
        => T.Of(
            TReal.Acos(T.Real(t)),
            -T.Dual(t) / (TReal.One - T.Real(t)*T.Real(t)).Sqrt());
    
    static T IRealFunctions<T>.Atan(T t)
        => T.Of(
            TReal.Acos(T.Real(t)),
            T.Dual(t) / (TReal.One + T.Real(t)*T.Real(t)));
}