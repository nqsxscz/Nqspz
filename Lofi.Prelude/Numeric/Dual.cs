using Lofi.Prelude.Data.Numeric.Instance;
using Lofi.Prelude.Numeric.Trait;
using Lofi.Prelude.Type.Constant;

namespace Lofi.Prelude.Numeric;

public static class Dual
{
    public static DualNumber<RealNumber, TNumber>
        ToConstant<TNumber>(
            this RealNumber x)
        where TNumber : INumber<TNumber>
        => x.ToConstant<
            DualNumber<RealNumber, TNumber>, 
            RealNumber, 
            TNumber>();
    
    public static TDual
        ToConstant<TDual, TReal, TNumber>(
            this TReal x)
        where TDual : IDual<TDual, TReal, TNumber>
        where TReal : IReal<TReal>
        where TNumber : INumber<TNumber>
        => TDual.ToConstant(x);
    
    public static DualNumber<RealNumber, TNumber>
        ToVariable<TNumber>(
            this RealNumber x,
            int i)
        where TNumber : INumber<TNumber>
        => x.ToVariable<
            DualNumber<RealNumber, TNumber>, 
            RealNumber, 
            TNumber>(i);
    
    public static TDual
        ToVariable<TDual, TReal, TNumber>(
            this TReal x,
            int i)
        where TDual : IDual<TDual, TReal, TNumber>
        where TReal : IReal<TReal>
        where TNumber : INumber<TNumber>
        => TDual.ToVariable(x, i);
}