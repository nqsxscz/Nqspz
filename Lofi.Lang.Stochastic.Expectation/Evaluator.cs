using Lofi.Lang.Stochastic.Expectation.Implementation;
using Lofi.Lang.Stochastic.Expectation.Type;

namespace Lofi.Lang.Stochastic.Expectation;

public static class Evaluator
{
    public static IExpectationEvaluator Montecarlo
        => new MontecarloExpectationEvaluator();
}