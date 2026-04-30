using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb;_category",
                table: "tb;_category");

            migrationBuilder.RenameTable(
                name: "tb;_category",
                newName: "tbl_category");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "tbl_user",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_category",
                table: "tbl_category");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "tbl_user");

            migrationBuilder.RenameTable(
                name: "tbl_category",
                newName: "tb;_category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb;_category",
                table: "tb;_category",
                column: "Id");
        }
    }
}
