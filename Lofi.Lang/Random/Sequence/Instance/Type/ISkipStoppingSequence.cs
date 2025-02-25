namespace Lofi.Lang.Random.Sequence.Instance.Type;

public interface ISkipStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Operand { get; }

    int Count { get; }
}