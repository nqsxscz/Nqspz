using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static bool
        Occurred(
            this IStoppingSequence sequence,
            DateTime t)
        => sequence
            .Occurrences(t)
            .Any();
}