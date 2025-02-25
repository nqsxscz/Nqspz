using Lofi.Lang.Model.Random.Process.Instance.Type;
using Lofi.Prelude.Data.Instance.Seq.Type;
using Lofi.Prelude.Numeric.Trait;

namespace Lofi.Lang.Model.Random.Process;

public static partial class StochasticProcess
{
    public static IStochasticProcess<T> Of<T>(
        ISeq<DateTime> times,
        T init,
        Func<T, T, T, T> f,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            Wiener<T>(times), 
            init, 
            f, 
            g);
    
    public static IStochasticProcess<T> Of<T>(
        IStochasticProcess<T> wiener,
        T init,
        Func<T, T, T, T> f,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Time(wiener.Times)
            .Differentiate()
            .Scan(
                wiener
                    .Differentiate(),
                init, 
                f.With(g));

    public static IStochasticProcess<T> Of<T>(
        IStochasticProcess<T> process,
        T init,
        Func<T, T, T, T, T> f,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Of(
            Wiener<T>(process.Times), 
            process,
            init, 
            f, 
            g);
    
    public static IStochasticProcess<T> Of<T>(
        IStochasticProcess<T> wiener,
        IStochasticProcess<T> process,
        T init,
        Func<T, T, T, T, T> f,
        Func<TimeSpan, T> g)
        where T : IReal<T>
        => Time(process.Times)
            .Differentiate()
            .Scan(
                wiener
                    .Differentiate(),
                process,
                init, 
                f.With(g));
    
    private static Func<T, TimeSpan, T, T> With<T>(
        this Func<T, T, T, T> f,
        Func<TimeSpan, T> g)
        => (a, b, c)
            => f(a, g(b), c);
    
    private static Func<T, TimeSpan, T, T, T> With<T>(
        this Func<T, T, T, T, T> f,
        Func<TimeSpan, T> g)
        => (a, b, c, d)
            => f(a, g(b), c, d);
}