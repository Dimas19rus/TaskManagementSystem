// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.MainTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<int>("FactualLaborIntensity");

                    b.Property<string>("Name");

                    b.Property<int>("NumberStatus");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Performers");

                    b.Property<int>("PlannedLaborIntensity");

                    b.HasKey("ID");

                    b.HasIndex("ParentId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Главная задача 1",
                            NumberStatus = 1,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 2,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 1_1",
                            NumberStatus = 1,
                            ParentId = 1,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 3,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 1_2",
                            NumberStatus = 1,
                            ParentId = 1,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 4,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 1_2_1",
                            NumberStatus = 1,
                            ParentId = 3,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 5,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Главная задача 2",
                            NumberStatus = 1,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 6,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 2_1",
                            NumberStatus = 1,
                            ParentId = 5,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 7,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 2_1_1",
                            NumberStatus = 1,
                            ParentId = 6,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 8,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 2_1_1_1",
                            NumberStatus = 1,
                            ParentId = 7,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 9,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 2_1_1_1_1",
                            NumberStatus = 1,
                            ParentId = 8,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        },
                        new
                        {
                            ID = 10,
                            DateRegistration = new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deadline = new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Описание задачи",
                            FactualLaborIntensity = 5,
                            Name = "Подзадача 2_2",
                            NumberStatus = 1,
                            ParentId = 5,
                            Performers = "пупкин",
                            PlannedLaborIntensity = 30
                        });
                });

            modelBuilder.Entity("Domain.Models.MainTask", b =>
                {
                    b.HasOne("Domain.Models.MainTask", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
