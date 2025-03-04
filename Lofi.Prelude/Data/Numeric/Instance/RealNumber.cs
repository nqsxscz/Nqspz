using Lofi.Prelude.Numeric.Trait;
using MathNet.Numerics.Distributions;

namespace Lofi.Prelude.Data.Numeric.Instance;

public readonly record struct RealNumber(double Value) 
    : IReal<RealNumber>
{
    public static RealNumber Zero
        => FromDouble(0);

    public static RealNumber One
        => FromDouble(1);
    
    public static RealNumber Pi
        => FromDouble(double.Pi);

    public static RealNumber E
        => FromDouble(double.E);
    
    public static RealNumber FromDouble(double x)
        => new(x);
    
    public static RealNumber Invert(RealNumber operand)
        => FromDouble(1/operand.Value);

    public static RealNumber operator ^(RealNumber left, RealNumber right)
        => FromDouble(double.Pow(left.Value, right.Value));
    
    public static RealNumber Sqrt(RealNumber operand)
        => FromDouble(double.Sqrt(operand.Value));

    public static RealNumber Log(RealNumber operand)
        => FromDouble(double.Log(operand.Value));

    public static RealNumber Exp(RealNumber operand)
        => FromDouble(double.Exp(operand.Value));

    public static RealNumber Sin(RealNumber operand)
        => FromDouble(double.Sin(operand.Value));

    public static RealNumber Cos(RealNumber operand)
        => FromDouble(double.Cos(operand.Value));

    public static RealNumber Tan(RealNumber operand)
        => FromDouble(double.Tan(operand.Value));

    public static RealNumber Asin(RealNumber operand)
        => FromDouble(double.Asin(operand.Value));

    public static RealNumber Acos(RealNumber operand)
        => FromDouble(double.Acos(operand.Value));

    public static RealNumber Atan(RealNumber operand)
        => FromDouble(double.Atan(operand.Value));
    
    public static RealNumber NormalCdf(RealNumber operand)
        => FromDouble(
            Normal.CDF(
                0, 
                1, 
                operand.Value));
    
    public static RealNumber operator -(RealNumber operand)
        => FromDouble(-operand.Value);
    
    public static RealNumber operator +(RealNumber left, RealNumber right)
        => FromDouble(left.Value + right.Value);

    public static RealNumber operator *(RealNumber left, RealNumber right)
        => FromDouble(left.Value * right.Value);
    
    public static bool operator <(RealNumber left, RealNumber right)
        => left.Value < right.Value;

    public static bool operator >(RealNumber left, RealNumber right)
        => right < left;
}