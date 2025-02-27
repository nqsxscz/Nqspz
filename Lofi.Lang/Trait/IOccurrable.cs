using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Trait;

public interface IOccurrable<in T>
    where T : IOccurrable<T>
{
    static abstract IMaybe<DateTime>
        Occurrence(
            T occurrable,
            DateTime t);
}