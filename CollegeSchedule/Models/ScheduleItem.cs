namespace CollegeSchedule.Models;

public class ScheduleItem
{
    public string Date { get; set; } = string.Empty;
    public string Weekday { get; set; } = string.Empty;
    public int LessonNumber { get; set; }
    public string Time { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Teacher { get; set; } = string.Empty;
    public string Room { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string GroupPart { get; set; } = string.Empty;
}