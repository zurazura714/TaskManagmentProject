using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagmentProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AppUsers",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "BriefDescription",
                table: "TaskDomains",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoles_AppUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "IsAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, true, "c66baf6e73684084c874846c6a4ab5f47bc53b153e3fb735dbcd8139a42f9915", "User1" },
                    { 2, false, "24f15e3f6711bef3bbbb18da10dbc5f7df3ca7e869a02c18f315cd1310f75704", "User2" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "Role", "UserID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AppUsers",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "BriefDescription",
                table: "TaskDomains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
