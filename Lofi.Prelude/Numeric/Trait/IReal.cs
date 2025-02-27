namespace Lofi.Prelude.Numeric.Trait;

public interface IReal<T> : 
    INatural<T>, 
    IRealFunctions<T>
    where T : IReal<T>
{
    static abstract T FromDouble(double x);
    
    static abstract T operator ^(
        T left, 
        T right);
}