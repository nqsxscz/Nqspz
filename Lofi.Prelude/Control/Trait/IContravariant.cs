using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface IContravariant<TC>
    where TC : notnull, IContravariant<TC>
{
    static abstract ITypeConstructor<TC, T1>
        ContraSelect<T1, T2>(
            ITypeConstructor<TC, T2> operand,
            Func<T1, T2> f)
        where T1 : notnull
        where T2 : notnull;
}