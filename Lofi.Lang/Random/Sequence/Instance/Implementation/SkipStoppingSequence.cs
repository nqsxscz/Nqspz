using Lofi.Lang.Random.Sequence.Instance.Type;

namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record SkipStoppingSequence(
    IStoppingSequence Operand,
    int Count)
    : ISkipStoppingSequence;