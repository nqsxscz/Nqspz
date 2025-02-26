using Lofi.Lang.Model.Random.Variable.Instance.Type;

namespace Lofi.Lang.Model.Random.Variable.Instance.Implementation;

internal sealed record SelectRandomVariable<T1, T2>(
    IRandomVariable<T1> Operand,
    Func<T1, T2> Selector)
    : ISelectRandomVariable<T1, T2> 
    where T1 : notnull
    where T2 : notnull;