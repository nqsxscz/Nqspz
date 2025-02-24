namespace Lofi.Lang.Random.Sequence.Instance.Implementation;

internal sealed record TakeStoppingSequence(
    IStoppingSequence Operand,
    int Count)
    : ITakeStoppingSequence;