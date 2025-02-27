using Lofi.Lang.Observable.Temporal.Continuous.Instance.Implementation;
using Lofi.Lang.Observable.Temporal.Continuous.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Continuous;

public static partial class Temporal
{
    public static ITemporal<DateTime> Time
        => new TimeTemporal();
}