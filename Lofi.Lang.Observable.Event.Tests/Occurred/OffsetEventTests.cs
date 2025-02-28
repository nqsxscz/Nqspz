using Lofi.Lang.Observable.Event.Single;
using Shouldly;

namespace Lofi.Lang.Observable.Event.Tests.Occurred;

public class OffsetEventTests
{
    [Test]
    public void Should_Occurr_At_Offset_Date()
    {
        var date = DateTime.Now;
        var dt = TimeSpan.FromDays(1);
        var @event = date
            .ToEvent()
            .Offset(dt);
        @event.Occurred(date).ShouldBeFalse();
        @event.Occurred(date+dt).ShouldBeTrue();
    }
}