using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApiRepository.Migrations
{
    /// <inheritdoc />
    public partial class addseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "Id", "DOB", "Designation", "ImageURL", "IsPermanent", "Name", "Salary" },
                values: new object[] { 1, new DateOnly(1992, 1, 1), "Officer", "", true, "Hasan", 10000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "employees");
        }
    }
}
