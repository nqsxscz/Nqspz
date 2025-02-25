using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Time.Instance.Implementation;

internal sealed record PredicateStoppingTime(
    IStoppedProcess<bool> Predicate,
    int Index)
    : IPredicateStoppingTime;