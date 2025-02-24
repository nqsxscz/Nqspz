using Lofi.Lang.Random.Process.PiecewiseConstant.Instance;

namespace Lofi.Lang.Random.Time.Instance;

public interface IPredicateStoppingTime
    : IStoppingTime
{
    IStoppedProcess<bool> Predicate { get; }

    int Index { get; }
}