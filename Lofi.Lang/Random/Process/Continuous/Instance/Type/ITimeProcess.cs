using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous.Instance.Type;

public interface ITimeProcess
    : IProcess<DateTime>
{
    IMaybe<DateTime> IProcess<DateTime>.Observe(DateTime t)
        => t.ToMaybe();
}