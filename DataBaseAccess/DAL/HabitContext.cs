using Microsoft.EntityFrameworkCore;
using WAD.Models;
using System.Data.Common;
using WAD.Repositories;
using System;

namespace WAD.DAL
{
    public class HabitContext : DbContext
    {
        public HabitContext(DbContextOptions<HabitContext> o) :base(o)
        {
            Database.EnsureCreated();
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Progress> Progresses { get; set; }

    }
}
