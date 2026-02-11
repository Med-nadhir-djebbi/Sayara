using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sayara.Migrations
{
    /// <inheritdoc />
    public partial class AddListingVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VerificationStatus",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VerificationNotes",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifiedDate",
                table: "Listings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationStatus",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "VerificationNotes",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "VerifiedDate",
                table: "Listings");
        }
    }
}
