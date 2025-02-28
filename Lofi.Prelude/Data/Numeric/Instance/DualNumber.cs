using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type.Constant;

namespace Lofi.Prelude.Data.Numeric.Instance;

public sealed record DualNumber<TReal, TNumber>(
    TReal RealValue, 
    TReal[] DualValues)
    : IDual<DualNumber<TReal, TNumber>, TReal, TNumber>
    where TReal : IReal<TReal>
    where TNumber : INumber<TNumber>
{
    public static TReal Real(DualNumber<TReal, TNumber> dualNumber)
        => dualNumber.RealValue;

    public static TReal[] Duals(DualNumber<TReal, TNumber> dualNumber)
        => dualNumber.DualValues;

    public static DualNumber<TReal, TNumber> Of(TReal real, TReal[] duals)
    {
        if (duals.Length != TNumber.Number)
            throw new ArgumentException(
                $"Duals must have a size of {TNumber.Number}");
        return new DualNumber<TReal, TNumber>(real, duals);
    }

    public static DualNumber<TReal, TNumber> ToVariable(TReal real, int i)
    {
        var duals = new TReal[TNumber.Number];
        for (var j = 0; j < TNumber.Number; j++)
            duals[j] = j == i - 1 ?
                TReal.One : TReal.Zero;
        return Of(real, duals);
    }
}