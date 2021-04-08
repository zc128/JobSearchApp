using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearchApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppliedJob",
                columns: table => new
                {
                    AppliedJobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    JobPostingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedJob", x => x.AppliedJobID);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Company = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    YearEstablished = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    ResumeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HighestEducation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    WorkExperience = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.ResumeID);
                    table.ForeignKey(
                        name: "FK_Resumes_Candidates_UserID",
                        column: x => x.UserID,
                        principalTable: "Candidates",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    JobPostingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CompanyAddress = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.JobPostingID);
                    table.ForeignKey(
                        name: "FK_JobPostings_Employers_UserID",
                        column: x => x.UserID,
                        principalTable: "Employers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_Notifications_Candidates_UserID",
                        column: x => x.UserID,
                        principalTable: "Candidates",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_Employers_UserID",
                        column: x => x.UserID,
                        principalTable: "Employers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedSearches",
                columns: table => new
                {
                    SavedSearchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    EmployerID = table.Column<int>(type: "int", nullable: true),
                    SearchedTerm = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedSearches", x => x.SavedSearchID);
                    table.ForeignKey(
                        name: "FK_SavedSearches_Candidates_UserID",
                        column: x => x.UserID,
                        principalTable: "Candidates",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavedSearches_Employers_UserID",
                        column: x => x.UserID,
                        principalTable: "Employers",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Coverletter = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    JobPostingID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ResumeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_JobApplications_Candidates_UserID",
                        column: x => x.UserID,
                        principalTable: "Candidates",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPostings_JobPostingID",
                        column: x => x.JobPostingID,
                        principalTable: "JobPostings",
                        principalColumn: "JobPostingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplications_Resumes_ResumeID",
                        column: x => x.ResumeID,
                        principalTable: "Resumes",
                        principalColumn: "ResumeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostingID",
                table: "JobApplications",
                column: "JobPostingID");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_ResumeID",
                table: "JobApplications",
                column: "ResumeID");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserID",
                table: "JobApplications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_JobPostings_UserID",
                table: "JobPostings",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UserID",
                table: "Resumes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SavedSearches_UserID",
                table: "SavedSearches",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedJob");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SavedSearches");

            migrationBuilder.DropTable(
                name: "JobPostings");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
