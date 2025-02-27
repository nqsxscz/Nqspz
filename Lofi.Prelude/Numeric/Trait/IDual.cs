using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;

namespace Lofi.Prelude.Numeric.Trait;

public interface IDual<T, TReal> : 
    IReal<T>
    where T : IDual<T, TReal>
    where TReal : IReal<TReal>
{
    static abstract TReal Real(T t);

    static abstract TReal Dual(T t);

    static abstract T Of(
        TReal real, 
        TReal dual);

    static virtual T FromReal(TReal real)
        => T.Of(
            real, 
            TReal.Zero);
    
    static T IAdditiveSemigroup<T>.operator +(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var up = T.Dual(left);
        var vp = T.Dual(right);
        var l = u + v;
        var r = up + vp;
        return T.Of(l, r);
    }
    
    static T IAdditiveMonoid<T>.Zero
        => T.FromReal(TReal.Zero);
    
    static T IAdditiveGroup<T>.operator -(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var up = T.Dual(left);
        var vp = T.Dual(right);
        var l = u - v;
        var r = up - vp;
        return T.Of(l, r);
    }
    
    static T IMultiplicativeSemigroup<T>.operator *(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var up = T.Dual(left);
        var vp = T.Dual(right);
        var l = u * v;
        var r = up*v + u*vp;
        return T.Of(l, r);
    }
    
    static T IMultiplicativeMonoid<T>.One
        => T.FromReal(TReal.One);
    
    static T IMultiplicativeGroup<T>.operator /(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var up = T.Dual(left);
        var vp = T.Dual(right);
        var l = u / v;
        var r = (up*v - u*vp) / v.Square();
        return T.Of(l, r);
    }

    static T IReal<T>.FromDouble(double x)
        => T.FromReal(
            TReal.FromDouble(x));
    
    static T IReal<T>.Pi
        => T.FromReal(TReal.Pi);
    
    static T IReal<T>.E
        => T.FromReal(TReal.E);
    
    static T IReal<T>.Sqrt(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Sqrt();
        var r = up / (TReal.Two*u.Sqrt());
        return T.Of(l, r);
    }
    
    static T IReal<T>.Log(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Log();
        var r = up / u;
        return T.Of(l, r);
    }
    
    static T IReal<T>.Exp(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Exp();
        var r = up * u.Exp();
        return T.Of(l, r);
    }

    static T IReal<T>.Sin(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Sin();
        var r = up * u.Cos();
        return T.Of(l, r);
    }
    
    static T IReal<T>.Cos(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Cos();
        var r = -up * u.Sin();
        return T.Of(l, r);
    }
    
    static T IReal<T>.Tan(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Tan();
        var r = up / u.Cos().Square();
        return T.Of(l, r);
    }
    
    static T IReal<T>.Asin(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Asin();
        var r = up / (TReal.One - u.Square()).Sqrt();
        return T.Of(l, r);
    }
    
    static T IReal<T>.Acos(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Acos();
        var r = -up / (TReal.One - u.Square()).Sqrt();
        return T.Of(l, r);
    }
    
    static T IReal<T>.Atan(T t)
    {
        var u = T.Real(t);
        var up = T.Dual(t);
        var l = u.Atan();
        var r = up / (TReal.One + u.Square());
        return T.Of(l, r);
    }

    static T IReal<T>.operator ^(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var up = T.Dual(left);
        var vp = T.Dual(right);
        var l = u ^ v;
        var r = 
            up * v * (u ^ (v - TReal.One))
            + u.Log()*u*v*vp;
        return T.Of(l, r);
    }
}