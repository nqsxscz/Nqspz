using Lofi.Lang.Random.Event.Set.Instance.Operator;
using Lofi.Lang.Random.Event.Set.Instance.Type;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;

namespace Lofi.Lang.Random.Event.Set;

public static partial class EventSet
{
    public static IOrderedEnumerable<DateTime>
        Occurrences(
            this IEventSet sequence,
            DateTime t)
        => sequence switch
        {
            IBinaryOperationEventSet
                {
                    Left: var left,
                    Right: var right,
                    Operator: AfterOperator
                } =>
                left.OccurrencesAfter(right, t),
            IBinaryOperationEventSet
                {
                    Left: var left,
                    Right: var right,
                    Operator: BeforeOperator
                } =>
                left.OccurrencesBefore(right, t),
            IBinaryOperationEventSet
                {
                    Left: var left,
                    Right: var right,
                    Operator: ExceptOperator
                } =>
                left.Occurrences(t)
                    .Except(right.Occurrences(t))
                    .Order(),
            IBinaryOperationEventSet
                {
                    Left: var left,
                    Right: var right,
                    Operator: IntersectOperator
                } =>
                left.Occurrences(t)
                    .Intersect(right.Occurrences(t))
                    .Order(),
            IBinaryOperationEventSet
                {
                    Left: var left,
                    Right: var right,
                    Operator: UnionOperator
                } =>
                left.Occurrences(t)
                    .Union(right.Occurrences(t))
                    .Order(),
            ITakeEventSet
                {
                    Operand: var operand,
                    Count: var count
                } =>
                operand
                    .Occurrences(t)
                    .Take(count)
                    .Order(),
            ISkipEventSet
                {
                    Operand: var operand,
                    Count: var count
                } =>
                operand
                    .Occurrences(t)
                    .Skip(count)
                    .Order(),
            ISequenceEventSet
                {
                    StoppingTimes: var stoppingTimes
                } =>
                stoppingTimes
                    .Select(Single.Event.Occurrence(t))
                    .SelectMany(Maybe.ToEnumerable)
                    .Order(),
            _ =>
                Enumerable
                    .Empty<DateTime>()
                    .Order()
        };

    private static IOrderedEnumerable<DateTime>
        Occurrences(
            this IEventSet left,
            IEventSet right,
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
            this IEventSet left,
            IEventSet right,
            DateTime t)
        => left.Occurrences(
            right,
            t,
            first =>
                s =>
                    s > first);

    private static IOrderedEnumerable<DateTime>
        OccurrencesBefore(
            this IEventSet left,
            IEventSet right,
            DateTime t)
        => left.Occurrences(
            right,
            t,
            first =>
                s =>
                    s <= first);
}