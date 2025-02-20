using Algebra.Operators;

namespace Algebra.Lattices;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TJoinOperator"></typeparam>
/// <typeparam name="TMeetOperator"></typeparam>
/// <remarks>
/// TODO: Need to figure out how to handle absorption laws.
/// </remarks>
public interface ILattice<T, TJoinOperator, TMeetOperator>
    where T : 
        ILattice<T, TJoinOperator, TMeetOperator>,
        IJoinSemilattice<T, TJoinOperator>,
        IMeetSemilattice<T, TMeetOperator>
    where TJoinOperator : IJoinBinaryOperator
    where TMeetOperator : IMeetBinaryOperator;