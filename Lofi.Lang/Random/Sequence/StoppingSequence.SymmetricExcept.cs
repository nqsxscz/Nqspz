using Lofi.Lang.Random.Sequence.Instance;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IStoppingSequence SymmetricExcept(
        this IStoppingSequence left,
        IStoppingSequence right)
        => left
            .Except(right)
            .Union(
                right
                    .Except(left));
}