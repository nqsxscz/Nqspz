using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Prelude.Data.Numeric.Instance;

public readonly record struct NaturalNumber(int Value)
    : INatural<NaturalNumber>
{
    public static NaturalNumber FromInt(int n)
        => new(n);
    
    public static NaturalNumber Zero
        => FromInt(0);
    
    public static NaturalNumber One
        => FromInt(1);
    
    public static NaturalNumber operator -(NaturalNumber operand)
        => FromInt(-operand.Value);
    
    public static NaturalNumber operator +(NaturalNumber left, NaturalNumber right)
        => FromInt(left.Value + right.Value);

    public static NaturalNumber operator *(NaturalNumber left, NaturalNumber right)
        => FromInt(left.Value * right.Value);
    
    public static bool operator <(NaturalNumber left, NaturalNumber right)
        => left.Value < right.Value;

    public static bool operator >(NaturalNumber left, NaturalNumber right)
        => right > left;
}