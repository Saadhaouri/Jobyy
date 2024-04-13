using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Joby.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Clm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Companies_CompanyId1",
                table: "Opportunity");

            migrationBuilder.DropIndex(
                name: "IX_Opportunity_CompanyId1",
                table: "Opportunity");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "Opportunity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Opportunity",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CompanyId",
                table: "Opportunity",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Companies_CompanyId",
                table: "Opportunity",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opportunity_Companies_CompanyId",
                table: "Opportunity");

            migrationBuilder.DropIndex(
                name: "IX_Opportunity_CompanyId",
                table: "Opportunity");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "Opportunity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                table: "Opportunity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CompanyId1",
                table: "Opportunity",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunity_Companies_CompanyId1",
                table: "Opportunity",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
