using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServeSchools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCreatedDateContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "schools",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2024, 2, 16, 6, 24, 40, 894, DateTimeKind.Utc).AddTicks(7182),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_date",
                table: "schools",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 2, 16, 6, 24, 40, 894, DateTimeKind.Utc).AddTicks(7182));
        }
    }
}
