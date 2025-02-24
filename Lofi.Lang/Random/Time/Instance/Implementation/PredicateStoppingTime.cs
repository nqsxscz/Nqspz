using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;

namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record PredicateStoppingTime(
    IStoppedProcess<bool> Predicate,
    int Index)
    : IPredicateStoppingTime;