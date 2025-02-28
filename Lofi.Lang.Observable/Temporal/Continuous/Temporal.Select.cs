using Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<T2> Select<T1, T2>(this 
        ITemporal<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => new SelectTemporal<T1, T2>(
            operand,
            selector);
}