using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asma.pl.Data.Migrations
{
    /// <inheritdoc />
    public partial class MainHome1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a2a9da0-78c5-4e5c-9cff-607b5e25df0f", "58aac1ad-91b2-4480-bef7-4afaecd43ebc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "26279ccf-8cec-4ba5-ab97-a70cd817fffa", "b962711d-9cdb-46a8-adad-059537f0d05e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "52ebf65b-a539-4f91-bab0-681935a8f81a", "f889485d-19f2-49e6-8383-6e5db5f8cd8d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26279ccf-8cec-4ba5-ab97-a70cd817fffa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52ebf65b-a539-4f91-bab0-681935a8f81a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a2a9da0-78c5-4e5c-9cff-607b5e25df0f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "58aac1ad-91b2-4480-bef7-4afaecd43ebc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b962711d-9cdb-46a8-adad-059537f0d05e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f889485d-19f2-49e6-8383-6e5db5f8cd8d");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "MainHomes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cbce2440-6e2d-436b-a815-4693243b77c6", null, "SuperAdmin", "SUPERADMIN" },
                    { "d4120123-b443-4aea-8ebd-11f10a11ec56", null, "User", "USER" },
                    { "f14836cf-c9bc-4830-b304-1110b6eac683", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "20e87e81-8713-45b1-b21b-280eea8a2bf0", 0, null, "bc6b908f-bf91-4226-9eea-a8bd2273e2da", "superAdmin@comp.com", true, false, null, "SUPERADMIN@COMP.COM", "SUPERADMIN@COMP.COM", "AQAAAAIAAYagAAAAEFRKJlE0ia+gGuQ/tQDEH08PRBdkSWWQWO0aXtlu26oPmaqOhGypq0VXv4BAISB8Nw==", null, false, "e28da246-3506-47b1-8b31-5bb8555fa13a", false, "superAdmin@comp.com" },
                    { "3bd62bc8-aea0-4036-b83f-8e87037dd142", 0, null, "67a3a191-aa39-4a60-bdc3-80a2d5e2e9f9", "admin@comp.com", true, false, null, "ADMIN@COMP.COM", "ADMIN@COMP.COM", "AQAAAAIAAYagAAAAEPx8rHDvQ8QxH9WYJsM+I5MznwTIB6vzh6HSDTWoIC+nRzsFczDJKQXqatgr1/pEbg==", null, false, "43e24097-97ae-4d69-b68a-87b3d9eda452", false, "admin@comp.com" },
                    { "9df0e160-cf41-4219-a3d1-1f7c22c2fef1", 0, null, "cb9d2e6e-f0ac-4480-9fd0-4aea911500db", "user@comp.com", true, false, null, "USER@COMP.COM", "User@COMP.COM", "AQAAAAIAAYagAAAAEKyTtvrQNhaxANZJHA7BB5eqw0Nxs6gkU0spfyxgb6GLqrgApvDQQV9386vO925o+g==", null, false, "41847256-edfd-4c16-b2fe-ddc66f359dc5", false, "user@comp.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cbce2440-6e2d-436b-a815-4693243b77c6", "20e87e81-8713-45b1-b21b-280eea8a2bf0" },
                    { "f14836cf-c9bc-4830-b304-1110b6eac683", "3bd62bc8-aea0-4036-b83f-8e87037dd142" },
                    { "d4120123-b443-4aea-8ebd-11f10a11ec56", "9df0e160-cf41-4219-a3d1-1f7c22c2fef1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cbce2440-6e2d-436b-a815-4693243b77c6", "20e87e81-8713-45b1-b21b-280eea8a2bf0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f14836cf-c9bc-4830-b304-1110b6eac683", "3bd62bc8-aea0-4036-b83f-8e87037dd142" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d4120123-b443-4aea-8ebd-11f10a11ec56", "9df0e160-cf41-4219-a3d1-1f7c22c2fef1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbce2440-6e2d-436b-a815-4693243b77c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4120123-b443-4aea-8ebd-11f10a11ec56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f14836cf-c9bc-4830-b304-1110b6eac683");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "20e87e81-8713-45b1-b21b-280eea8a2bf0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3bd62bc8-aea0-4036-b83f-8e87037dd142");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9df0e160-cf41-4219-a3d1-1f7c22c2fef1");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "MainHomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26279ccf-8cec-4ba5-ab97-a70cd817fffa", null, "Admin", "ADMIN" },
                    { "52ebf65b-a539-4f91-bab0-681935a8f81a", null, "SuperAdmin", "SUPERADMIN" },
                    { "5a2a9da0-78c5-4e5c-9cff-607b5e25df0f", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "58aac1ad-91b2-4480-bef7-4afaecd43ebc", 0, null, "607be02f-fa32-4ce5-a7c4-d3a549ea39d4", "user@comp.com", true, false, null, "USER@COMP.COM", "User@COMP.COM", "AQAAAAIAAYagAAAAEGs9R+FrCGf9aXJ6qMJy4bNsU3XvR138GERZnwRYKUcJT7b/tphgPLYA0DryKILh1g==", null, false, "3ebe7ab3-d71a-4c24-9a55-8695fae233e9", false, "user@comp.com" },
                    { "b962711d-9cdb-46a8-adad-059537f0d05e", 0, null, "7413b9d2-85d1-4bd3-96e1-47d157e468cf", "admin@comp.com", true, false, null, "ADMIN@COMP.COM", "ADMIN@COMP.COM", "AQAAAAIAAYagAAAAEEACJJ+XWkCXLMCfaW/Ex6xy4zrDKMMb2F6NNwHtVHifWWyhlYfN3A15Jn2jgztq3Q==", null, false, "19786b70-a019-4fb9-b708-34d3fcf99229", false, "admin@comp.com" },
                    { "f889485d-19f2-49e6-8383-6e5db5f8cd8d", 0, null, "25ece60c-76cc-4e53-a7ab-345a9e393c35", "superAdmin@comp.com", true, false, null, "SUPERADMIN@COMP.COM", "SUPERADMIN@COMP.COM", "AQAAAAIAAYagAAAAEC+wCgusiOy6FgJz9A/sIaHLNVuHcNzL61uhmVr4jQtKASkxbMcmH0YpzKMgSQhZoQ==", null, false, "0df482cb-52b3-4355-addb-1210d1b5057d", false, "superAdmin@comp.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5a2a9da0-78c5-4e5c-9cff-607b5e25df0f", "58aac1ad-91b2-4480-bef7-4afaecd43ebc" },
                    { "26279ccf-8cec-4ba5-ab97-a70cd817fffa", "b962711d-9cdb-46a8-adad-059537f0d05e" },
                    { "52ebf65b-a539-4f91-bab0-681935a8f81a", "f889485d-19f2-49e6-8383-6e5db5f8cd8d" }
                });
        }
    }
}
