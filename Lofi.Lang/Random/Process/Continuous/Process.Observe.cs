using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.Visitor;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IMaybe<T> Observe<T>(
        this IContinuousProcess<T> continuousProcess, 
        DateTime t)
        where T : notnull
        => continuousProcess
            .Accept(ProcessVisitor.Observe(t))
            .ToMaybe();
}