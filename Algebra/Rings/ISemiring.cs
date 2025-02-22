using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;

namespace Algebra.Rings;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISemiring<T>
    where T :
        ISemiring<T>,
        IAdditiveMonoid<T>,
        IMultiplicativeMonoid<T>;