using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpNameId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isOrg = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmpNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAssociations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAssociations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectForms_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_ProjectForms_FormId",
                        column: x => x.FormId,
                        principalTable: "ProjectForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    ProjectFormId = table.Column<int>(type: "int", nullable: true),
                    OrgNameId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_ProjectForms_ProjectFormId",
                        column: x => x.ProjectFormId,
                        principalTable: "ProjectForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Submissions_SubmissionId",
                        column: x => x.SubmissionId,
                        principalTable: "Submissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "Description", "Email", "EmpNameId", "LastUpdatedOn", "OrgNameId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(8890), "No description", "test@mail.com", "emp1", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(8890), "org1", "username1" },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(8894), "No description", "test@mail.com", "emp2", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(8895), "org1", "username2" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Description", "Duration", "EndDate", "LastUpdatedOn", "Name", "OrgNameId", "Progress", "StartDate", "Status", "isOrg" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9098), "user1", "Project 1 started", "12 Months", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9098), "Project1", "org1", "6 months", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9096), "In progres", true },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9102), "user1", "Project 1 started", "12 Months", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9103), "Project2", null, "6 months", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9102), "In progres", false }
                });

            migrationBuilder.InsertData(
                table: "ProjectAssociations",
                columns: new[] { "Id", "CreatedDate", "Description", "EmpNameId", "EmployeeId", "LastUpdatedOn", "OrgNameId", "ProjectId", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9125), "The project manager", "emp1", 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9126), "org1", 1, "Project Manager" },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9129), "The project manager", "emp2", 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9129), "org1", 1, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "ProjectForms",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Description", "FormData", "LastUpdatedOn", "OrgNameId", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9154), "user1", "Form 1", "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9155), "org1", 1, "Form1" },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9158), "user1", "Form 2", "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9158), null, 2, "Form2" }
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Description", "FormId", "LastUpdatedOn", "OrgNameId", "SubmissionData", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9215), "user1", "Submission 1", 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9215), "org1", "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}", "Submission1" },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9219), "user1", "Submission 2", 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9219), null, "{\"name\":\"Uhanmi V1\",\"description\":\"This is the first or cover image of Uhanmi NFT collection.\",\"image\":\"https://gateway.pinata.cloud/ipfs/QmXxtXrGznUsGoyMCRqCKVU53cuJPeQFxJHmWWiZ74TLvv\"}", "Submission2" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CreatedDate", "CreatorId", "Description", "LastUpdatedOn", "OrgNameId", "ProjectFormId", "ReportData", "Status", "SubmissionId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9186), "user1", "Report 1", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9187), "org1", null, "my report", null, 1, "Report1" },
                    { 2, new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9190), "user1", "report 2", new DateTime(2023, 9, 23, 10, 38, 36, 739, DateTimeKind.Local).AddTicks(9191), null, null, "my report", null, 2, "Report2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssociations_EmployeeId",
                table: "ProjectAssociations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssociations_ProjectId",
                table: "ProjectAssociations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectForms_ProjectId",
                table: "ProjectForms",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectFormId",
                table: "Reports",
                column: "ProjectFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_SubmissionId",
                table: "Reports",
                column: "SubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_FormId",
                table: "Submissions",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAssociations");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Submissions");

            migrationBuilder.DropTable(
                name: "ProjectForms");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
