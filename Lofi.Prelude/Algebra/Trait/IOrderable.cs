namespace Lofi.Prelude.Algebra.Trait;

public interface IOrderable<T>
    where T : notnull, IOrderable<T>
{
    static abstract bool operator <(T left, T right);
    
    static abstract bool operator >(T left, T right);
    
    static abstract bool operator <=(T left, T right);
    
    static abstract bool operator >=(T left, T right);
    
    static abstract T Minimum(T left, T right);
    
    static abstract T Maximum(T left, T right);
}