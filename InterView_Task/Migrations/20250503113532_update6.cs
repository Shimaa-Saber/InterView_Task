using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterView_Task.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65073535-ae4d-4420-a915-a5c016d126d5", 0, "c2d182f3-b3fa-49df-80c5-db513f001f7c", "shimaasaber224@gmail.com", true, null, null, false, null, "SHIMAASABER224@GMAIL.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEM2ixX71MlnuPwOLr3P55EbBtu6b4wc5KDzsoQuUKok38rdz8RmkrNsnttVRmri28g==", "0123456789", true, null, "fecb0e1f-6be7-4c4c-a91d-47189b0d3c47", false, "AdminShimaa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65073535-ae4d-4420-a915-a5c016d126d5");
        }
    }
}
