using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;

namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IPredicateStoppingTime
    : IStoppingTime
{
    IStoppedProcess<bool> Predicate { get; }

    int Index { get; }
}