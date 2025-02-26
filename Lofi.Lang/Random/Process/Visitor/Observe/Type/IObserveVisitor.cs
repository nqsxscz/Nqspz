using Lofi.Lang.Random.Process.Continuous;
using Lofi.Lang.Random.Process.Continuous.Instance.Type;
using Lofi.Lang.Random.Process.PiecewiseConstant.Instance.Type;
using Lofi.Lang.Random.Sequence;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Process.Visitor.Observe.Type;

public interface IObserveVisitor
    : IProcessVisitor<IMaybe>
{
    DateTime Time { get; }
    
    ITypeConstructor<IMaybe, DateTime> 
        IProcessVisitor<IMaybe>.Visit(
            ITimeProcess process)
        => Time.ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IProcessVisitor<IMaybe>.Visit<T>(
            IEmptyProcess<T> process) 
        => Maybe.Nothing<T>();

    ITypeConstructor<IMaybe, T> 
        IProcessVisitor<IMaybe>.Visit<T>(
            IConstantProcess<T> process) 
        => process
            .Value
            .ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IProcessVisitor<IMaybe>.Visit<T>(
            IFlattenProcess<T> process) 
        => process
            .Operand
            .Observe(Time)
            .Flatten()
            .ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IStoppedProcessVisitor<IMaybe>.Visit<T>(
            IDiscretizedStoppedProcess<T> process)
        => process
            .StoppingSequence
            .Occurrences(Time)
            .MaybeLast()
            .SelectMany(
                process
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IStoppedProcessVisitor<IMaybe>.Visit<T>(
            IOffsetStoppedProcess<T> process)
        => process
            .StoppingSequence
            .Occurrences(Time)
            .SkipLast(
                process
                    .Offset)
            .MaybeLast()
            .SelectMany(
                process
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IStoppedProcessVisitor<IMaybe>.Visit<T>(
            ISupplierStoppedProcess<T> process)
        => process
            .Supplier
            .Times
            .Where(s => s <= Time)
            .MaybeLast()
            .SelectMany(
                process
                    .Supplier
                    .Ask(process.Key))
            .ToMaybe();

    ITypeConstructor<IMaybe, T2> 
        IProcessVisitor<IMaybe>.Visit<T1, T2>(
            ISelectProcess<T1, T2> process)
        => process
            .Operand
            .Observe(Time)
            .Select(process.Selector)
            .ToMaybe();

    ITypeConstructor<IMaybe, T3> 
        IProcessVisitor<IMaybe>.Visit<T1, T2, T3>(
            ILiftProcess<T1, T2, T3> process)
        => process
            .Left
            .Observe(Time)
            .Lift(
                process
                    .Right
                    .Observe(Time),
                process
                    .Combinator)
            .ToMaybe();
}