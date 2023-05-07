using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class MyMygration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoneModelasCollection",
                table: "DoneModelasCollection");

            migrationBuilder.RenameTable(
                name: "DoneModelasCollection",
                newName: "DoneModelCollection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoneModelCollection",
                table: "DoneModelCollection",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DoneModelCollection",
                table: "DoneModelCollection");

            migrationBuilder.RenameTable(
                name: "DoneModelCollection",
                newName: "DoneModelasCollection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoneModelasCollection",
                table: "DoneModelasCollection",
                column: "Id");
        }
    }
}
