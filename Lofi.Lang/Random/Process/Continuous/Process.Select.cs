using Lofi.Lang.Random.Process.Continuous.Instance.Implementation;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;

namespace Lofi.Lang.Random.Process.Continuous;

public static partial class Process
{
    public static IContinuousProcess<T2> Select<T1, T2>(
        this IContinuousProcess<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => new SelectContinuousProcess<T1, T2>(
            operand,
            selector);
}