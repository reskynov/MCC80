using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddDefaultRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("24706f51-2651-4cd2-9ca0-c8e510969b7d"), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7496), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7496), "Admin" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("4016bbf3-5514-4478-97f8-85a3baef09c2"), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7493), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7494), "Manager" });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[] { new Guid("5eeda544-ee8f-495d-9366-6c04e0904a5c"), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7480), new DateTime(2023, 7, 31, 20, 45, 1, 210, DateTimeKind.Local).AddTicks(7490), "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("24706f51-2651-4cd2-9ca0-c8e510969b7d"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("4016bbf3-5514-4478-97f8-85a3baef09c2"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("5eeda544-ee8f-495d-9366-6c04e0904a5c"));
        }
    }
}
