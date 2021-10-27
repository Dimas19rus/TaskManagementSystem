using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Performers = table.Column<string>(nullable: true),
                    DateRegistration = table.Column<DateTime>(nullable: false),
                    NumberStatus = table.Column<int>(nullable: false),
                    PlannedLaborIntensity = table.Column<int>(nullable: false),
                    FactualLaborIntensity = table.Column<int>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 1, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Главная задача 1", 1, null, "пупкин", 30 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 5, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Главная задача 2", 1, null, "пупкин", 30 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 1_1", 1, 1, "пупкин", 30 },
                    { 3, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 1_2", 1, 1, "пупкин", 30 },
                    { 6, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 2_1", 1, 5, "пупкин", 30 },
                    { 10, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 2_2", 1, 5, "пупкин", 30 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 4, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 1_2_1", 1, 3, "пупкин", 30 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 7, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 2_1_1", 1, 6, "пупкин", 30 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 8, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 2_1_1_1", 1, 7, "пупкин", 30 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "DateRegistration", "Deadline", "Description", "FactualLaborIntensity", "Name", "NumberStatus", "ParentId", "Performers", "PlannedLaborIntensity" },
                values: new object[] { 9, new DateTime(2021, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание задачи", 5, "Подзадача 2_1_1_1_1", 1, 8, "пупкин", 30 });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ParentId",
                table: "Tasks",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
