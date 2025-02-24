using Lofi.Lang.Random.Time.Instance;

namespace Lofi.Lang.Random.Sequence.Instance;

public interface IStoppingTimesSequence
    : IStoppingSequence
{
    IEnumerable<IStoppingTime> StoppingTimes { get; }
}