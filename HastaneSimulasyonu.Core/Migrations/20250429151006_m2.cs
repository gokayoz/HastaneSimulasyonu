using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneSimulasyonu.Core.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Hasta");

            migrationBuilder.AddColumn<string>(
                name: "Sikayet",
                table: "Hasta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sikayet",
                table: "Hasta");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "Hasta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
