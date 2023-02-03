using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.Migrations
{
    public partial class initDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39cf7308-1d2a-4e24-b526-a708b5fbb666", "d7eb2ee7-9a17-4d53-9c11-1f5d53b0833b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbb5a0c2-80c8-47c6-b7cf-e86b3a8c3acd", "ef193cb7-db2b-4045-95b2-f1d36cc5bd6d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39cf7308-1d2a-4e24-b526-a708b5fbb666");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbb5a0c2-80c8-47c6-b7cf-e86b3a8c3acd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7eb2ee7-9a17-4d53-9c11-1f5d53b0833b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef193cb7-db2b-4045-95b2-f1d36cc5bd6d");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83fab3fb-761e-4525-a5bd-367b5a76e89b", "c7b5b452-e60e-4855-bc6d-a5a15193195e", "Standart", "STANDART" },
                    { "9571ab97-95bf-4b64-972b-aefd49305ab3", "c254a1ac-78f3-4ef2-b02f-4b480f9397cd", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "40dc1ebd-46ed-4fd3-8f0c-3514ad217943", 0, "e54eaa4c-11eb-425c-bc57-69d6547f428b", "Standart", "standart@standart.com", true, "Standart", null, "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEGLD5fTPALGWP3xf22zZolOdWkLJ151VPa1GEDEEboiorGCwRkpMPgQUrljE2jPZWA==", null, false, new DateTime(2023, 2, 3, 12, 26, 51, 582, DateTimeKind.Local).AddTicks(2615), "be7ae4b6-dc81-4d23-bf9d-595f786d0818", false, "standart@standart.com" },
                    { "6ec78949-4531-4a62-8156-81ac96f34f9a", 0, "1eb8477c-d57b-457b-a8f8-cb02c9ad2a07", "Admin", "admin@admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJxFz3aI/EqLNx0pX55wGcrU/vjWv6FYwnO1TwTiBQJKhKPvv6fHR6QH7a8EfvdsQg==", null, false, new DateTime(2023, 2, 3, 12, 26, 51, 581, DateTimeKind.Local).AddTicks(1695), "a9c65205-6ea4-48e2-b9c4-467c9e202a3d", false, "admin@admin.com" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "6ec78949-4531-4a62-8156-81ac96f34f9a");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "83fab3fb-761e-4525-a5bd-367b5a76e89b", "40dc1ebd-46ed-4fd3-8f0c-3514ad217943" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9571ab97-95bf-4b64-972b-aefd49305ab3", "6ec78949-4531-4a62-8156-81ac96f34f9a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83fab3fb-761e-4525-a5bd-367b5a76e89b", "40dc1ebd-46ed-4fd3-8f0c-3514ad217943" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9571ab97-95bf-4b64-972b-aefd49305ab3", "6ec78949-4531-4a62-8156-81ac96f34f9a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83fab3fb-761e-4525-a5bd-367b5a76e89b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9571ab97-95bf-4b64-972b-aefd49305ab3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40dc1ebd-46ed-4fd3-8f0c-3514ad217943");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ec78949-4531-4a62-8156-81ac96f34f9a");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39cf7308-1d2a-4e24-b526-a708b5fbb666", "321178a4-cf5d-43af-8055-3f1c09264855", "Admin", "ADMIN" },
                    { "cbb5a0c2-80c8-47c6-b7cf-e86b3a8c3acd", "a4e34f38-8c31-46dc-b961-33fe6f8a4933", "Standart", "STANDART" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d7eb2ee7-9a17-4d53-9c11-1f5d53b0833b", 0, "1224bced-9a30-4ef1-b922-20e847a8d246", "Admin", "admin@admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEE8lOkVoU0KnPqNm3CFcPqj+iTqPEtfrNADvsUsTiyP76iP08C+f8Z1PNjINCOarJQ==", null, false, new DateTime(2023, 2, 2, 16, 30, 15, 899, DateTimeKind.Local).AddTicks(9990), "42270538-f0dd-48c8-bc14-32f69bf944fa", false, "admin@admin.com" },
                    { "ef193cb7-db2b-4045-95b2-f1d36cc5bd6d", 0, "06ddc88a-505d-48ca-bef6-295af3e71b6d", "Standart", "standart@standart.com", true, "Standart", null, "Standart", false, null, "STANDART@STANDART.COM", "STANDART@STANDART.COM", "AQAAAAEAACcQAAAAEAy/Oxs57Y4Shjfk168m142+7Opnthjh5iQYBFPB71srLAH9zWNEl4ou4jDIXrrySg==", null, false, new DateTime(2023, 2, 2, 16, 30, 15, 901, DateTimeKind.Local).AddTicks(1233), "22262f4c-fc22-4c63-915b-10ad58acffc9", false, "standart@standart.com" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "d7eb2ee7-9a17-4d53-9c11-1f5d53b0833b");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "39cf7308-1d2a-4e24-b526-a708b5fbb666", "d7eb2ee7-9a17-4d53-9c11-1f5d53b0833b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cbb5a0c2-80c8-47c6-b7cf-e86b3a8c3acd", "ef193cb7-db2b-4045-95b2-f1d36cc5bd6d" });
        }
    }
}
