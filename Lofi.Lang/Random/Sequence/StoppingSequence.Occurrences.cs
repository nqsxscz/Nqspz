using Lofi.Lang.Random.Sequence.Instance.Operator;
using Lofi.Lang.Random.Sequence.Instance.Type;
using Lofi.Lang.Random.Time;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Sequence;

public static partial class StoppingSequence
{
    public static IOrderedEnumerable<DateTime>
        Occurrences(
            this IStoppingSequence sequence,
            DateTime t)
        => sequence switch
        {
            IBinaryOperationStoppingSequence
                {
                    Left: var left,
                    Right: var right,
                    Operator: AfterOperator
                } =>
                left.OccurrencesAfter(right, t),
            IBinaryOperationStoppingSequence
                {
                    Left: var left,
                    Right: var right,
                    Operator: BeforeOperator
                } =>
                left.OccurrencesBefore(right, t),
            IBinaryOperationStoppingSequence
                {
                    Left: var left,
                    Right: var right,
                    Operator: ExceptOperator
                } =>
                left.Occurrences(t)
                    .Except(right.Occurrences(t))
                    .Order(),
            IBinaryOperationStoppingSequence
                {
                    Left: var left,
                    Right: var right,
                    Operator: IntersectOperator
                } =>
                left.Occurrences(t)
                    .Intersect(right.Occurrences(t))
                    .Order(),
            IBinaryOperationStoppingSequence
                {
                    Left: var left,
                    Right: var right,
                    Operator: UnionOperator
                } =>
                left.Occurrences(t)
                    .Union(right.Occurrences(t))
                    .Order(),
            ITakeStoppingSequence
                {
                    Operand: var operand,
                    Count: var count
                } =>
                operand
                    .Occurrences(t)
                    .Take(count)
                    .Order(),
            ISkipStoppingSequence
                {
                    Operand: var operand,
                    Count: var count
                } =>
                operand
                    .Occurrences(t)
                    .Skip(count)
                    .Order(),
            IStoppingTimesSequence
                {
                    StoppingTimes: var stoppingTimes
                } =>
                stoppingTimes
                    .Select(StoppingTime.Occurrence(t))
                    .SelectMany(Maybe.ToEnumerable)
                    .Order(),
            _ =>
                Enumerable
                    .Empty<DateTime>()
                    .Order()
        };

    private static IOrderedEnumerable<DateTime>
        Occurrences(
            this IStoppingSequence left,
            IStoppingSequence right,
            DateTime t,
            Func<DateTime, Func<DateTime, bool>> predicate)
    {
        var occurrences1 = left.Occurrences(t);
        var occurrences2 = right.Occurrences(t);
        return occurrences2
            .MaybeFirst()
            .Select(first =>
                occurrences1
                    .Where(predicate(first)))
            .ToMaybe()
            .OrElse([])
            .Order();
    }

    private static IOrderedEnumerable<DateTime>
        OccurrencesAfter(
            this IStoppingSequence left,
            IStoppingSequence right,
            DateTime t)
        => left.Occurrences(
            right,
            t,
            first =>
                s =>
                    s > first);

    private static IOrderedEnumerable<DateTime>
        OccurrencesBefore(
            this IStoppingSequence left,
            IStoppingSequence right,
            DateTime t)
        => left.Occurrences(
            right,
            t,
            first =>
                s =>
                    s <= first);
}