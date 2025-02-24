namespace Lofi.Lang.Random.Sequence.Instance;

public interface ISkipStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Operand { get; }

    int Count { get; }
}