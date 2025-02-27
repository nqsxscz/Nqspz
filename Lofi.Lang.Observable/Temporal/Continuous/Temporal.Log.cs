using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T> Log<T>(
        this ITemporal<T> operand)
        where T : IReal<T>
        => operand
            .Select(
                T.Log);
}