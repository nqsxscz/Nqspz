using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe;

namespace Lofi.Lang.Random.Process.Continuous.Instance;

public interface ITimeProcess
    : IProcess<DateTime>
{
    IMaybe<DateTime> IProcess<DateTime>.Observe(DateTime t)
        => t.ToMaybe();
}