using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeSchedule.Data;
using CollegeSchedule.Models;

namespace CollegeSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly AppDbContext _context;

    public ScheduleController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("group/{groupName}")]
    public async Task<ActionResult<IEnumerable<ScheduleItem>>> GetSchedule(string groupName)
    {
        try
        {
            var sql = @"
            SELECT 
                s.lesson_date::text AS ""Date"",
                w.name AS ""Weekday"",
                lt.lesson_number AS ""LessonNumber"",
                CONCAT(lt.time_start::text, ' - ', lt.time_end::text) AS ""Time"",
                subj.name AS ""Subject"",
                CONCAT(t.last_name, ' ', t.first_name) AS ""Teacher"",
                c.room_number AS ""Room"",
                b.name AS ""Building"",
                s.group_part::text AS ""GroupPart""
            FROM schedule s
            JOIN student_group g ON g.group_id = s.group_id
            JOIN weekday w ON w.weekday_id = s.weekday_id
            JOIN lesson_time lt ON lt.lesson_time_id = s.lesson_time_id
            JOIN subject subj ON subj.subject_id = s.subject_id
            JOIN teacher t ON t.teacher_id = s.teacher_id
            JOIN classroom c ON c.classroom_id = s.classroom_id
            JOIN building b ON b.building_id = c.building_id
            WHERE g.group_name = {0}
            ORDER BY s.lesson_date, lt.lesson_number";
            var schedule = await _context.ScheduleItems
                .FromSqlRaw(sql, groupName)
                .ToListAsync();

            return Ok(schedule);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}