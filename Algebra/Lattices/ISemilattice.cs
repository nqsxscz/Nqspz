using Algebra.Groups;
using Algebra.Operators;

namespace Algebra.Lattices;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TOperator"></typeparam>
public interface ISemilattice<T, TOperator>
    : IIdempotentSemigroup<T, TOperator>
    where T : ISemilattice<T, TOperator>
    where TOperator : IBinaryOperator;