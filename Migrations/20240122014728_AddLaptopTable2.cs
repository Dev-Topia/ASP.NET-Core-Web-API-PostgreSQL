using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiWithPostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddLaptopTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptops",
                table: "Laptops");

            migrationBuilder.RenameTable(
                name: "Laptops",
                newName: "Laptop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptop",
                table: "Laptop",
                column: "LaptopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Laptop",
                table: "Laptop");

            migrationBuilder.RenameTable(
                name: "Laptop",
                newName: "Laptops");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Laptops",
                table: "Laptops",
                column: "LaptopId");
        }
    }
}
