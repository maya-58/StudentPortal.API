using Microsoft.EntityFrameworkCore.Migrations;

namespace studentportal.api.Migrations
{
    public partial class TableColumnCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lname",
                table: "Student",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Fname",
                table: "Student",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "DOB",
                table: "Student",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "PostallAddress",
                table: "Address",
                newName: "PostalAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "Lname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "Fname");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Student",
                newName: "DOB");

            migrationBuilder.RenameColumn(
                name: "PostalAddress",
                table: "Address",
                newName: "PostallAddress");
        }
    }
}
