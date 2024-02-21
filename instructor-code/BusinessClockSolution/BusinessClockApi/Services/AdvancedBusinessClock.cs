namespace BusinessClockApi.Services;

public class AdvancedBusinessClock(ISystemTime systemTime) : IProvideTheBusinessClock
{
    public bool IsOpen()
    {
        var now = systemTime.GetCurrent();

        var dayOfWeek = now.DayOfWeek;
        if (now.Month == 12 && now.Day == 25)
        {
            return false;
        }

        var hour = now.Hour;
        var openingTime = new TimeSpan(9, 0, 0);
        var closingTime = new TimeSpan(17, 0, 0);

        var isOpen = dayOfWeek switch
        {
            DayOfWeek.Sunday => false,
            DayOfWeek.Saturday => false,
            _ => hour >= openingTime.Hours && hour < closingTime.Hours
        };
        return isOpen;
    }
}
