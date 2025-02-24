using Lofi.Lang.Random.Time.Instance;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record StoppingTimesSequence(
    IEnumerable<IStoppingTime> StoppingTimes)
    : IStoppingTimesSequence;