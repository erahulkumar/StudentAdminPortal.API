using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentAdminPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class SomeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Moblie",
                table: "Student",
                newName: "Mobile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Student",
                newName: "Moblie");
        }
    }
}
