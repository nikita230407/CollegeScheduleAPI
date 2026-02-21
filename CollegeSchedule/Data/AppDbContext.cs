using Microsoft.EntityFrameworkCore;
using CollegeSchedule.Models;

namespace CollegeSchedule.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ScheduleItem> ScheduleItems => Set<ScheduleItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScheduleItem>().HasNoKey();
    }
}