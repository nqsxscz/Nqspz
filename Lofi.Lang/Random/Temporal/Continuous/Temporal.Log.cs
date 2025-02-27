using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Random.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Log<T>(
        this ITemporal<T> operand)
        where T : IRealFunctions<T>
        => operand
            .Select(
                T.Log);
}