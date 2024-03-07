using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDev_Labb2.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class usch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "Lastname");

            migrationBuilder.AddColumn<bool>(
                name: "Discontinued",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discontinued",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Customers",
                newName: "Name");
        }
    }
}
