using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLOG.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcd23dd2-0d33-4a5f-a77b-eb8a9026fe1a", "2bbf73b8-0fb2-492d-b85d-277ae2ae174d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4200ce6c-f67a-43ee-84a2-19728c642efb", "3b639c0b-af35-4512-8e90-67fcf6760dc1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4200ce6c-f67a-43ee-84a2-19728c642efb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcd23dd2-0d33-4a5f-a77b-eb8a9026fe1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2bbf73b8-0fb2-492d-b85d-277ae2ae174d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b639c0b-af35-4512-8e90-67fcf6760dc1");

            migrationBuilder.AddColumn<string>(
                name: "a",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e1d6f5d-d990-4f62-854b-98385f463d2f", "141d3b16-9fd4-44ad-b7b8-1b7a31568bf2", "Admin", "ADMIN" },
                    { "9704302d-29c6-4fb3-8944-4d3e3dc79143", "e678034a-caed-4052-b5b3-4a43e4d2f6e2", "Standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName", "a" },
                values: new object[,]
                {
                    { "279de4eb-05c4-4e24-8a2a-4c7f6f80c533", 0, "8e378a30-59f1-4e5b-9d0d-30376cbfbb61", null, "standard@standard.com", true, "Standard", null, "Standard", false, null, "STANDARD@STANDARD.COM", "STANDARD@STANDARD.COM", "AQAAAAEAACcQAAAAEM8aySVbI6U/NNJNryR5H40oCdNkpj2VTRGh8ESDXNEQp/DtzeuNKqg4q2TEM+ZB6A==", null, false, new DateTime(2023, 2, 14, 21, 55, 26, 459, DateTimeKind.Local).AddTicks(7151), "42185709-5d91-4f74-8fb8-442fed839db9", false, "standard@standard.com", null },
                    { "59ec33e9-b52a-4180-9c73-cd3ca01f3f1f", 0, "2f6fb9a3-6603-4160-848b-ef86ac4c65cf", null, "admin@admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEFhUQbUga+cF/tvdlA7kmPjUIhgKIVR7DjKUbBOd6+E/SKbU/sqBf6w+lGXZRRJuBQ==", null, false, new DateTime(2023, 2, 14, 21, 55, 26, 458, DateTimeKind.Local).AddTicks(1206), "5525afb5-b8da-439c-b579-8c757c1ede6a", false, "admin@admin.com", null }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "59ec33e9-b52a-4180-9c73-cd3ca01f3f1f");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9704302d-29c6-4fb3-8944-4d3e3dc79143", "279de4eb-05c4-4e24-8a2a-4c7f6f80c533" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e1d6f5d-d990-4f62-854b-98385f463d2f", "59ec33e9-b52a-4180-9c73-cd3ca01f3f1f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9704302d-29c6-4fb3-8944-4d3e3dc79143", "279de4eb-05c4-4e24-8a2a-4c7f6f80c533" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e1d6f5d-d990-4f62-854b-98385f463d2f", "59ec33e9-b52a-4180-9c73-cd3ca01f3f1f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1d6f5d-d990-4f62-854b-98385f463d2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9704302d-29c6-4fb3-8944-4d3e3dc79143");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "279de4eb-05c4-4e24-8a2a-4c7f6f80c533");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "59ec33e9-b52a-4180-9c73-cd3ca01f3f1f");

            migrationBuilder.DropColumn(
                name: "a",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4200ce6c-f67a-43ee-84a2-19728c642efb", "f98498f9-2b98-4db6-ad76-9825a013ea9d", "Standard", "STANDARD" },
                    { "fcd23dd2-0d33-4a5f-a77b-eb8a9026fe1a", "6d46135b-bfdc-4f71-a9d2-b91ee12549f4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Description", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2bbf73b8-0fb2-492d-b85d-277ae2ae174d", 0, "dab1dbf0-7b19-4c77-af6b-496287aa2f44", null, "admin@admin.com", true, "Admin", null, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEG048cW5pGnfVLudX48/H3qW64FgBk6OOmre3Qf6MtYWAIVNjfhtdxHOUSnu+PAKSQ==", null, false, new DateTime(2023, 2, 14, 16, 50, 7, 238, DateTimeKind.Local).AddTicks(4834), "c085dc14-2dfe-4a98-a88c-3c7798c282bf", false, "admin@admin.com" },
                    { "3b639c0b-af35-4512-8e90-67fcf6760dc1", 0, "fb061b96-deca-4b80-8e05-c06e52797d01", null, "standard@standard.com", true, "Standard", null, "Standard", false, null, "STANDARD@STANDARD.COM", "STANDARD@STANDARD.COM", "AQAAAAEAACcQAAAAENBidvMGhDnczAY0sN8d0z4GsYQSSL9pE91nMxRr3mXi72naZEymIj/DPaqNS9cC6w==", null, false, new DateTime(2023, 2, 14, 16, 50, 7, 239, DateTimeKind.Local).AddTicks(4798), "85e028c1-7813-4901-b4c6-f0fe2e0f3288", false, "standard@standard.com" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "2bbf73b8-0fb2-492d-b85d-277ae2ae174d");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fcd23dd2-0d33-4a5f-a77b-eb8a9026fe1a", "2bbf73b8-0fb2-492d-b85d-277ae2ae174d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4200ce6c-f67a-43ee-84a2-19728c642efb", "3b639c0b-af35-4512-8e90-67fcf6760dc1" });
        }
    }
}
