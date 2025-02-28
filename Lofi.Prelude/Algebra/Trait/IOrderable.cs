namespace Lofi.Prelude.Algebra.Trait;

public interface IOrderable<T>
    where T : notnull, IOrderable<T>
{
    static abstract bool operator <(T left, T right);

    static virtual bool operator <=(T left, T right)
        => left < right || left.Eq(right);

    static virtual bool operator >(T left, T right)
        => right < left;
    
    static virtual bool operator >=(T left, T right)
        => right <= left;

    static virtual bool operator ==(T left, T right)
        => left != null && left.Equals(right);
    
    static virtual bool operator !=(T left, T right)
        => !(left == right);
    
    static virtual T Minimum(T left, T right)
        => left < right ? left : right;
    
    static virtual T Maximum(T left, T right)
        => left >= right ? left : right;
}