using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTdotnet.Migrations
{
    /// <inheritdoc />
    public partial class db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "value",
                table: "sensors",
                newName: "lastValue");

            migrationBuilder.RenameColumn(
                name: "Categories",
                table: "sensors",
                newName: "values");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "values",
                table: "sensors",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "lastValue",
                table: "sensors",
                newName: "value");
        }
    }
}
