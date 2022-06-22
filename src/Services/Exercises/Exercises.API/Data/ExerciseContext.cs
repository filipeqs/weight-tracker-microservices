﻿using MongoDB.Driver;
using Exercises.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercises.API.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
    }
}
