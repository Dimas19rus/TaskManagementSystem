using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<MainTask> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainTask>().HasData(
                new MainTask
                {
                    ID = 1,
                    Name = "Главная задача 1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                },
                new MainTask
                {
                    ID = 2,
                    Name = "Подзадача 1_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 1
                },
                new MainTask
                {
                    ID = 3,
                    Name = "Подзадача 1_2",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 1
                },
                new MainTask
                {
                    ID = 4,
                    Name = "Подзадача 1_2_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 3
                },
                new MainTask
                {
                    ID = 5,
                    Name = "Главная задача 2",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                },
                new MainTask
                {
                    ID = 6,
                    Name = "Подзадача 2_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 5

                },
                new MainTask
                {
                    ID = 7,
                    Name = "Подзадача 2_1_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 6
                },
                new MainTask
                {
                    ID = 8,
                    Name = "Подзадача 2_1_1_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 7
                },
                new MainTask
                {
                    ID = 9,
                    Name = "Подзадача 2_1_1_1_1",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 8
                },
                new MainTask
                {
                    ID = 10,
                    Name = "Подзадача 2_2",
                    Description = "Описание задачи",
                    Performers = "пупкин",
                    DateRegistration = new DateTime(2021, 10, 22),
                    NumberStatus = 1,
                    PlannedLaborIntensity = 30,
                    FactualLaborIntensity = 5,
                    Deadline = new DateTime(2021, 10, 25),
                    ParentId = 5
                });
        }
    }
}