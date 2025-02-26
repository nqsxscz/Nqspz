using Lofi.Lang.Model.Random.Variable.Instance.Implementation;
using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable;

public static partial class RandomVariable
{
    public static IRandomVariable<T2> Select<T1, T2>(
        this IRandomVariable<T1> operand,
        Func<T1, T2> selector)
        where T1 : notnull
        where T2 : notnull
        => new SelectRandomVariable<T1,T2>(
            operand, 
            selector);
}