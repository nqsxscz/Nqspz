using Lofi.Lang.Trait;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Time.Instance;

public interface IStoppingTime
    : IOneTimeOccurrable<IStoppingTime>
{
    static IMaybe<DateTime>
        IOneTimeOccurrable<IStoppingTime>.Occurrence(
            IStoppingTime stoppingTime,
            DateTime t)
        => stoppingTime.Occurrence(t);
}