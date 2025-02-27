using Lofi.Lang.Random.Event.Set;
using Lofi.Lang.Random.Temporal.Continuous;
using Lofi.Lang.Random.Temporal.Continuous.Instance.Type;
using Lofi.Lang.Random.Temporal.Discrete;
using Lofi.Lang.Random.Temporal.Discrete.Instance.Type;
using Lofi.Prelude.Control;
using Lofi.Prelude.Data;
using Lofi.Prelude.Data.Instance.Maybe.TypeConstructor;
using Lofi.Prelude.Type;
using Lofi.Supplier;

namespace Lofi.Lang.Random.Temporal.Visitor.Observe.Type;

public interface IObserveVisitor
    : ITemporalVisitor1<IMaybe>
{
    DateTime Time { get; }
    
    ITypeConstructor<IMaybe, DateTime> 
        ITemporalVisitor1<IMaybe>.Visit(
            ITimeTemporal temporal)
        => Time.ToMaybe();

    ITypeConstructor<IMaybe, T> 
        ITemporalVisitor1<IMaybe>.Visit<T>(
            IEmptyTemporal<T> temporal) 
        => Maybe.Nothing<T>();

    ITypeConstructor<IMaybe, T> 
        ITemporalVisitor1<IMaybe>.Visit<T>(
            IConstantTemporal<T> temporal) 
        => temporal
            .Value
            .ToMaybe();

    ITypeConstructor<IMaybe, T>
        ITemporalVisitor1<IMaybe>.Visit<T>(
            IOffsetTemporal<T> temporal)
        => temporal
            .Operand
            .Observe(
                temporal
                    .Offsetter(
                        Time, 
                        temporal
                            .Offset));
    
    ITypeConstructor<IMaybe, T> 
        ITemporalVisitor1<IMaybe>.Visit<T>(
            IFlattenTemporal<T> temporal) 
        => temporal
            .Operand
            .Observe(Time)
            .Flatten()
            .ToMaybe();

    ITypeConstructor<IMaybe, T> 
        IDiscreteTemporalVisitor1<IMaybe>.Visit<T>(
            IDiscretizedTemporal<T> temporal)
        => temporal
            .EventSet
            .Occurrences(Time)
            .MaybeLast()
            .SelectMany(
                temporal
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IDiscreteTemporalVisitor1<IMaybe>.Visit<T>(
            IOffsetDiscreteTemporal<T> temporal)
        => temporal
            .EventSet()
            .Occurrences(Time)
            .SkipLast(
                temporal
                    .Offset)
            .MaybeLast()
            .SelectMany(
                temporal
                    .Operand
                    .Observe)
            .ToMaybe();
    
    ITypeConstructor<IMaybe, T> 
        IDiscreteTemporalVisitor1<IMaybe>.Visit<T>(
            ISupplierDiscreteTemporal<T> temporal)
        => temporal
            .Supplier
            .Times
            .Where(s => s <= Time)
            .MaybeLast()
            .SelectMany(
                temporal
                    .Supplier
                    .Ask(temporal.Key))
            .ToMaybe();

    ITypeConstructor<IMaybe, T2> 
        ITemporalVisitor1<IMaybe>.Visit<T1, T2>(
            ISelectTemporal<T1, T2> temporal)
        => temporal
            .Operand
            .Observe(Time)
            .Select(temporal.Selector)
            .ToMaybe();

    ITypeConstructor<IMaybe, T3> 
        ITemporalVisitor1<IMaybe>.Visit<T1, T2, T3>(
            ILiftTemporal<T1, T2, T3> temporal)
        => temporal
            .Left
            .Observe(Time)
            .Lift(
                temporal
                    .Right
                    .Observe(Time),
                temporal
                    .Combinator)
            .ToMaybe();
}