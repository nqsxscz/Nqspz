namespace Lofi.Lang.Random.Sequence.Instance;

public interface ITakeStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Operand { get; }

    int Count { get; }
}