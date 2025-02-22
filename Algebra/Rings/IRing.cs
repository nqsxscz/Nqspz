using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;

namespace Algebra.Rings;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRing<T>
    : ISemiring<T>
    where T : 
        IRing<T>, 
        IAdditiveGroup<T>, 
        IMultiplicativeMonoid<T>;