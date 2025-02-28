using Lofi.Prelude.Type;

namespace Lofi.Prelude.Control.Trait;

public interface IScannable<TC>
    where TC : notnull, IScannable<TC>
{
    static abstract ITypeConstructor<TC, T2> 
        ScanRight<T1, T2>(
            ITypeConstructor<TC, T1> operand,
            T2 init,
            Func<T1, T2, T2> accumulator)
        where T1 : notnull
        where T2 : notnull;
}