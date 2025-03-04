using Lofi.Prelude.Algebra;
using Lofi.Prelude.Algebra.Trait;
using Lofi.Prelude.Algebra.Trait.Additive;
using Lofi.Prelude.Algebra.Trait.Multiplicative;
using Lofi.Prelude.Type.Constant;

namespace Lofi.Prelude.Numeric.Trait;

public interface IDual<T, TReal, TNumber> : 
    IReal<T>
    where T : IDual<T, TReal, TNumber>
    where TReal : IReal<TReal>
    where TNumber : INumber<TNumber>
{
    static abstract TReal Real(T t);

    static abstract TReal[] Duals(T t);

    static abstract T Of(
        TReal real, 
        TReal[] dual);
    
    static abstract T ToVariable(
        TReal real, 
        int i);
    
    static virtual T ToConstant(
        TReal real)
        => T.Of(
            real, 
            Enumerable
                .Repeat(
                    TReal.Zero, 
                    TNumber.Number)
                .ToArray());
    
    static T IReal<T>.FromDouble(double x)
        => T.ToConstant(
            TReal.FromDouble(x));
    
    static T IAdditiveMonoid<T>.Zero
        => T.ToConstant(TReal.Zero);
    
    static T IMultiplicativeMonoid<T>.One
        => T.ToConstant(TReal.One);
    
    static T IReal<T>.Pi
        => T.ToConstant(TReal.Pi);
    
    static T IReal<T>.E
        => T.ToConstant(TReal.E);
    
    static T IAdditiveSemigroup<T>.operator +(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var ups = T.Duals(left);
        var vps = T.Duals(right);
        var x = u + v;
        var ys = ups
            .Zip(vps, Semigroup.Add)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IMultiplicativeSemigroup<T>.operator *(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var ups = T.Duals(left);
        var vps = T.Duals(right);
        var x = u * v;
        var ys = ups
            .Zip(vps, (up, vp) =>
                up*v + u*vp)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.operator ^(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var ups = T.Duals(left);
        var vps = T.Duals(right);
        var l = v * (u ^ (v - TReal.One));
        var r = u.Log() * u * v;
        var x = u ^ v;
        var ys = ups
            .Zip(vps, (up, vp) =>
                up * l + vp * r)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IAdditiveGroup<T>.operator -(T operand)
    {
        var u = T.Real(operand);
        var ups = T.Duals(operand);
        var x = -u;
        var ys = ups
            .Select(Group.Negate)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IMultiplicativeGroup<T>.Invert(T operand)
    {
        var u = T.Real(operand);
        var ups = T.Duals(operand);
        var x = u.Invert();
        var invDenominator = x * x;
        var ys = ups
            .Select(up =>
                -up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Sqrt(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var x = u.Sqrt();
        var invDenominator = (TReal.Two*x).Invert();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Log(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var invDenominator = u.Invert();
        var x = u.Log();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Exp(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var x = u.Exp();
        var ys = ups
            .Select(up =>
                up * x)
            .ToArray();
        return T.Of(x, ys);
    }

    static T IReal<T>.Sin(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var cosu = u.Cos();
        var x = u.Sin();
        var ys = ups
            .Select(up =>
                up * cosu)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Cos(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var sinu = u.Sin();
        var x = u.Cos();
        var ys = ups
            .Select(up =>
                -up * sinu)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Tan(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var invDenominator = 
            u.Cos()
                .Square()
                .Invert();
        var x = u.Tan();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Asin(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var invDenominator = 
            (TReal.One - u.Square())
            .Sqrt()
            .Invert();
        var x = u.Asin();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Acos(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var invDenominator = 
            (TReal.One - u.Square())
            .Sqrt()
            .Invert();
        var x = u.Acos();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.Atan(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var invDenominator = 
            (TReal.One + u.Square())
            .Invert();
        var x = u.Atan();
        var ys = ups
            .Select(up =>
                up * invDenominator)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IReal<T>.NormalCdf(T t)
    {
        var u = T.Real(t);
        var ups = T.Duals(t);
        var dN = (-u*u/TReal.Two).Exp() / (TReal.Two*TReal.Pi).Sqrt();
        var x = u.NormalCdf();
        var ys = ups
            .Select(up =>
                up * dN)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static bool IOrderable<T>.operator <(T left, T right)
        => T.Real(left) < T.Real(right);
    
    static bool IOrderable<T>.operator >(T left, T right)
        => right < left;
    
    static T IOrderable<T>.Minimum(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var ups = T.Duals(left);
        var vps = T.Duals(right);
        var gu = u < v ? TReal.One : TReal.Zero;
        var gv = u < v ? TReal.Zero : TReal.One;
        var x = TReal.Minimum(u, v);
        var ys = ups
            .Zip(vps, (up, vp) =>
                up * gu + vp * gv)
            .ToArray();
        return T.Of(x, ys);
    }
    
    static T IOrderable<T>.Maximum(T left, T right)
    {
        var u = T.Real(left);
        var v = T.Real(right);
        var ups = T.Duals(left);
        var vps = T.Duals(right);
        var gu = u >= v ? TReal.One : TReal.Zero;
        var gv = u >= v ? TReal.Zero : TReal.One;
        var x = TReal.Maximum(u, v);
        var ys = ups
            .Zip(vps, (up, vp) =>
                up * gu + vp * gv)
            .ToArray();
        return T.Of(x, ys);
    }
}