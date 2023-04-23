using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "b7ee1f4ce2250364bf35506c1d24e3105615a389bfd0ab05459dc3c70ce764d6");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "d88edb4cbdddfcc540fe455ab81ba932d14a67970655dc037a0fa1e4e9b17e82");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "c66baf6e73684084c874846c6a4ab5f47bc53b153e3fb735dbcd8139a42f9915");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "24f15e3f6711bef3bbbb18da10dbc5f7df3ca7e869a02c18f315cd1310f75704");
        }
    }
}
