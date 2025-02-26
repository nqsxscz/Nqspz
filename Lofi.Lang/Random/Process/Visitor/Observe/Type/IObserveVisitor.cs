using Lofi.Lang.Random.Process.Continuous;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.Visitor.Observe.Type;

public interface IObserveVisitor
    : IContinuousProcessVisitor1<IMaybe>
{
    DateTime Time { get; }
    
    ITypeConstructor<IMaybe, DateTime> 
        IContinuousProcessVisitor1<IMaybe>.Visit(
            ITimeContinuousProcess continuousProcess)
        => Time.ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IContinuousProcessVisitor1<IMaybe>.Visit<T>(
            IEmptyContinuousProcess<T> continuousProcess) 
        => Maybe.Nothing<T>();

    ITypeConstructor<IMaybe, T> 
        IContinuousProcessVisitor1<IMaybe>.Visit<T>(
            IConstantContinuousProcess<T> continuousProcess) 
        => continuousProcess
            .Value
            .ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IContinuousProcessVisitor1<IMaybe>.Visit<T>(
            IFlattenContinuousProcess<T> continuousProcess) 
        => continuousProcess
            .Operand
            .Observe(Time)
            .Flatten()
            .ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IPiecewiseConstantProcessVisitor1<IMaybe>.Visit<T>(
            IDiscretizedPiecewiseConstantContinuousProcess<T> continuousProcess)
        => continuousProcess
            .StoppingSequence
            .Occurrences(Time)
            .MaybeLast()
            .SelectMany(
                continuousProcess
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IPiecewiseConstantProcessVisitor1<IMaybe>.Visit<T>(
            IOffsetPiecewiseConstantContinuousProcess<T> continuousProcess)
        => continuousProcess
            .StoppingSequence()
            .Occurrences(Time)
            .SkipLast(
                continuousProcess
                    .Offset)
            .MaybeLast()
            .SelectMany(
                continuousProcess
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IPiecewiseConstantProcessVisitor1<IMaybe>.Visit<T>(
            ISupplierPiecewiseConstantContinuousProcess<T> continuousProcess)
        => continuousProcess
            .Supplier
            .Times
            .Where(s => s <= Time)
            .MaybeLast()
            .SelectMany(
                continuousProcess
                    .Supplier
                    .Ask(continuousProcess.Key))
            .ToMaybe();

    ITypeConstructor<IMaybe, T2> 
        IContinuousProcessVisitor1<IMaybe>.Visit<T1, T2>(
            ISelectContinuousProcess<T1, T2> continuousProcess)
        => continuousProcess
            .Operand
            .Observe(Time)
            .Select(continuousProcess.Selector)
            .ToMaybe();

    ITypeConstructor<IMaybe, T3> 
        IContinuousProcessVisitor1<IMaybe>.Visit<T1, T2, T3>(
            ILiftContinuousProcess<T1, T2, T3> continuousProcess)
        => continuousProcess
            .Left
            .Observe(Time)
            .Lift(
                continuousProcess
                    .Right
                    .Observe(Time),
                continuousProcess
                    .Combinator)
            .ToMaybe();
}