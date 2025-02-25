namespace Lofi.Prelude.Numeric.Trait;

public interface IReal<T> : 
    INatural<T>
    where T : notnull, IReal<T>
{
    static abstract double ToDouble(T t);
    
    static abstract T FromDouble(double i);
}