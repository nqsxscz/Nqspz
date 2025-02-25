using Lofi.Lang.Random.Sequence.Instance.Operator;

namespace Lofi.Lang.Random.Sequence.Instance.Type;

public interface IBinaryOperationStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Left { get; }

    IStoppingSequence Right { get; }
    
    IOperator Operator { get; }
}