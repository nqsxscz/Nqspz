using Functional.HigherKindedTypes;

namespace Functional.Contravariants;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TC"></typeparam>
public interface IContravariant<TC>
    where TC : IContravariant<TC>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="operand"></param>
    /// <param name="f"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <returns></returns>
    static abstract ITypeConstructor<TC, T1>
        ContraSelect<T1, T2>(
            ITypeConstructor<TC, T2> operand, 
            Func<T1, T2> f);
}