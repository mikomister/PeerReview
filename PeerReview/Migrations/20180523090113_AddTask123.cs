using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PeerReview.Migrations
{
    public partial class AddTask123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descrition = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_TaskId",
                table: "Submissions",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Tasks_TaskId",
                table: "Submissions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Tasks_TaskId",
                table: "Submissions");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_TaskId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Submissions");
        }
    }
}
