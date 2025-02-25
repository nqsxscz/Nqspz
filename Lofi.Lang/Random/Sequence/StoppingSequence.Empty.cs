using Lofi.Lang.Random.Sequence.Instance.Implementation;
using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence Empty
        => new EmptyStoppingSequence();
}