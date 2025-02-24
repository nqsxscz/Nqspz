using Lofi.Lang.Random.Sequence.Instance.Operator;

namespace Lofi.Lang.Random.Sequence.Instance;

// ReSharper disable once UnusedTypeParameter
public interface IBinaryOperationStoppingSequence
    : IStoppingSequence
{
    IStoppingSequence Left { get; }

    IStoppingSequence Right { get; }
    
    IOperator Operator { get; }
}