using Lofi.Prelude.Control.Trait;
using Lofi.Prelude.Type;

namespace Lofi.Lang.Stochastic.Trajectory.TypeConstructor;

public interface ITrajectory : 
    IMonad<ITrajectory>,
    ITraversable<ITrajectory>
{
    static ITypeConstructor<ITrajectory, T> 
        IMonad<ITrajectory>.Return<T>(T t)
        => throw new NotImplementedException();

    static ITypeConstructor<ITrajectory, T2> 
        IMonad<ITrajectory>.SelectMany<T1, T2>(
            ITypeConstructor<ITrajectory, T1> operand, 
            Func<T1, ITypeConstructor<ITrajectory, T2>> selector)
        => throw new NotImplementedException();

    static T2 IFoldable<ITrajectory>.AggregateRight<T1, T2>(
        ITypeConstructor<ITrajectory, T1> operand, 
        T2 init, 
        Func<T1, T2, T2> f)
        => throw new NotImplementedException();

    static ITypeConstructor<TF, ITypeConstructor<ITrajectory, T2>> 
        ITraversable<ITrajectory>.Traverse<TF, T1, T2>(
            ITypeConstructor<ITrajectory, T1> operand, 
            Func<T1, ITypeConstructor<TF, T2>> f)
        => throw new NotImplementedException();
}