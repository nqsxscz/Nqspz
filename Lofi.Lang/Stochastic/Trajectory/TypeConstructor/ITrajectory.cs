using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Trajectory.TypeConstructor;

public interface ITrajectory : 
    IApplicative<ITrajectory>,
    IScannable<ITrajectory>,
    ITraversable<ITrajectory>
{
    static ITypeConstructor<ITrajectory, T2> 
        IFunctor<ITrajectory>.Select<T1, T2>(
            ITypeConstructor<ITrajectory, T1> operand, 
            Func<T1, T2> selector)
        => operand
            .ToTrajectory()
            .Select(selector);
    
    static ITypeConstructor<ITrajectory, T> 
        IApplicative<ITrajectory>.Pure<T>(T t)
        => t.ToTrajectory();

    static ITypeConstructor<ITrajectory, T3> 
        IApplicative<ITrajectory>.Lift<T1, T2, T3>(
            ITypeConstructor<ITrajectory, T1> left, 
            ITypeConstructor<ITrajectory, T2> right, 
            Func<T1, T2, T3> combinator)
        => RandomTrajectory
            .Lift(
                left.ToTrajectory(),
                right.ToTrajectory(),
                combinator);

    static ITypeConstructor<ITrajectory, T2>
        IScannable<ITrajectory>.ScanRight<T1, T2>(
            ITypeConstructor<ITrajectory, T1> operand,
            T2 init,
            Func<T1, T2, T2> accumulator)
        => operand
            .ToTrajectory()
            .ScanRight(
                init, 
                accumulator);

    static T2 IFoldable<ITrajectory>.AggregateRight<T1, T2>(
        ITypeConstructor<ITrajectory, T1> operand,
        T2 init,
        Func<T1, T2, T2> accumulator)
        => operand
            .ToTrajectory()
            .AggregateRight(
                init, 
                accumulator);

    static ITypeConstructor<TF, ITypeConstructor<ITrajectory, T2>>
        ITraversable<ITrajectory>.Traverse<TF, T1, T2>(
            ITypeConstructor<ITrajectory, T1> operand,
            Func<T1, ITypeConstructor<TF, T2>> f)
        => operand
            .ToTrajectory()
            .Traverse(f);
}