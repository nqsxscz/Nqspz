using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Trait;

public interface IOneTimeOccurrable<in T>
    where T : IOneTimeOccurrable<T>
{
    static abstract IMaybe<DateTime>
        Occurrence(
            T occurrable,
            DateTime t);
}