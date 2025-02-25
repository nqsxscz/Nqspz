using Lofi.Lang.Random.Time.Instance.Type;

namespace Lofi.Lang.Random.Sequence.Instance.Type;

public interface IStoppingTimesSequence
    : IStoppingSequence
{
    IEnumerable<IStoppingTime> StoppingTimes { get; }
}