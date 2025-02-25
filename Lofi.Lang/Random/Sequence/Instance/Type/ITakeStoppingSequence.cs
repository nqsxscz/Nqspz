namespace Lofi.Lang.Random.Sequence.Instance.Type;

public interface ITakeStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Operand { get; }

    int Count { get; }
}