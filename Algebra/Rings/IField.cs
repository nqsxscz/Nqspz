using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;

namespace Algebra.Rings;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IField<T>
    : IRing<T>
    where T : 
        IField<T>, 
        IAdditiveGroup<T>, 
        IMultiplicativeGroup<T>;