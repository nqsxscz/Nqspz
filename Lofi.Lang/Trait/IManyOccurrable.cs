namespace Lofi.Lang.Trait;

public interface IManyOccurrable<in T>
    where T : IManyOccurrable<T>
{
    static abstract IOrderedEnumerable<DateTime>
        Occurrences(
            T occurrable,
            DateTime t);
}