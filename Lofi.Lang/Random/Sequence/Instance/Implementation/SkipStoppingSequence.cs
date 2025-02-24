namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record SkipStoppingSequence(
    IStoppingSequence Operand,
    int Count)
    : ISkipStoppingSequence;