using Algebra.Groups.Additive;
using Algebra.Groups.Multiplicative;
using Algebra.Operators;

namespace Algebra.Rings;

public interface IField<T, TAddOperator, TMultiplyOperator>
    : IRing<T, TAddOperator, TMultiplyOperator>
    where T : 
        IField<T, TAddOperator, TMultiplyOperator>, 
        IAdditiveGroup<T, TAddOperator>, 
        IMultiplicativeGroup<T, TMultiplyOperator>
    where TAddOperator : IAddBinaryOperator
    where TMultiplyOperator : IMultiplyBinaryOperator;