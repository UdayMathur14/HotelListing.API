using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d468e59-4806-4de0-a4aa-c12f764a8654", null, "Administrator", "ADMINISTRATOR" },
                    { "a688d3eb-b9e1-4902-9f1b-c3f849d61773", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d468e59-4806-4de0-a4aa-c12f764a8654");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a688d3eb-b9e1-4902-9f1b-c3f849d61773");
        }
    }
}
