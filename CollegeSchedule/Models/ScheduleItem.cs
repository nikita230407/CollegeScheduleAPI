namespace CollegeSchedule.Models;

public class ScheduleItem
{
    public string Date { get; set; } = "";
    public string Weekday { get; set; } = "";
    public int LessonNumber { get; set; }
    public string Time { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Teacher { get; set; } = "";
    public string Room { get; set; } = "";
    public string Building { get; set; } = "";
    public string GroupPart { get; set; } = "";
}