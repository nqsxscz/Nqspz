using Lofi.Lang.Trait;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Time.Instance.Type;

public interface IStoppingTime
    : IOneTimeOccurrable<IStoppingTime>
{
    static IMaybe<DateTime>
        IOneTimeOccurrable<IStoppingTime>.Occurrence(
            IStoppingTime stoppingTime,
            DateTime t)
        => stoppingTime.Occurrence(t);
}