using Lofi.Lang.Random.Sequence.Operator;

namespace Lofi.Lang.Random.Sequence.Instance;

// ReSharper disable once UnusedTypeParameter
public interface IBinaryOperationStoppingSequence<out TOperator>
    : IStoppingSequence
    where TOperator : IBinaryOperator
{
    IStoppingSequence Left { get; }

    IStoppingSequence Right { get; }
}