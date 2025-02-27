using Lofi.Lang.Observable.Temporal.Discrete.Instance.Type;

namespace Lofi.Lang.Observable.Temporal.Discrete.Instance.Implementation;

internal sealed record OffsetDiscreteTemporal<T>(
    IDiscreteTemporal<T> Operand,
    int Offset) :
    IOffsetDiscreteTemporal<T>
    where T : notnull;