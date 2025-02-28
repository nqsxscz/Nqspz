using Lofi.Lang.Observable.Event.Single;
using Shouldly;

namespace Lofi.Lang.Observable.Event.Tests.Occurred;

public class MinimumEventTests
{
    [Test]
    public void Should_Occurr_At_Left_Date_When_Right_Date_After_Left_Date()
    {
        var date1 = DateTime.Now;
        var date2 = DateTime.Now + TimeSpan.FromDays(1);
        var @event = date1
            .ToEvent()
            .Minimum(date2.ToEvent());
        @event.Occurred(date1).ShouldBeTrue();
        @event.Occurred(date2).ShouldBeTrue();
    }
}