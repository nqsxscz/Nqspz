namespace Lofi.Lang.Trait;

public interface IOccurrable<in T>
    where T : IOccurrable<T>
{
    static abstract IOrderedEnumerable<DateTime>
        Occurrences(
            T occurrable,
            DateTime t);
}