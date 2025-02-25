using Lofi.Lang.Model.Random.Variable.Instance;
using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable;

public static partial class RandomVariable
{
    public static IRandomVariable<T3> Lift<T1, T2, T3>(
        IRandomVariable<T1> left,
        IRandomVariable<T2> right,
        Func<T1, T2, T3> combinator)
        where T1 : notnull
        where T2 : notnull
        where T3 : notnull
        => throw new NotImplementedException();
}