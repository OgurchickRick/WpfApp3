using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    DateofBirth = table.Column<string>(name: "Date_of_Birth", type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    FullYears = table.Column<int>(type: "INTEGER", nullable: false),
                    Citizenship = table.Column<string>(type: "TEXT", nullable: false),
                    PlaceOfResidence = table.Column<string>(type: "TEXT", nullable: false),
                    GraduatedFromGrades = table.Column<string>(type: "TEXT", nullable: false),
                    FinishedOnly = table.Column<string>(type: "TEXT", nullable: false),
                    AverageScoreOfCertificate = table.Column<double>(type: "REAL", nullable: false),
                    Snils = table.Column<string>(type: "TEXT", nullable: false),
                    DisabilityCertificate = table.Column<string>(type: "TEXT", nullable: false),
                    Orphan = table.Column<string>(type: "TEXT", nullable: false),
                    Speciality = table.Column<string>(type: "TEXT", nullable: false),
                    Certificate = table.Column<bool>(type: "INTEGER", nullable: false),
                    Money = table.Column<string>(type: "TEXT", nullable: false),
                    Enrollment = table.Column<bool>(type: "INTEGER", nullable: false),
                    YearOfAdmission = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
