using Lofi.Lang.Model.Random.Variable.Instance.Implementation;
using Lofi.Lang.Model.Random.Variable.Instance.Type;
using Lofi.Lang.Model.Random.Variable.Instance.TypeConstructor;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Model.Random.Variable;

public static partial class RandomVariable
{
    public static IRandomVariable<T> ToRandomVariable<T>(
        this ITypeConstructor<IRandomVariable, T> randomVariable)
        where T : notnull
        => (IRandomVariable<T>) randomVariable;
    
    public static IRandomVariable<T> ToRandomVariable<T>(
        this T t)
        where T : notnull
        => new ConstantRandomVariable<T>(t);
}