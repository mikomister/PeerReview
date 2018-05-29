using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PeerReview.Migrations
{
    public partial class uppre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Tasks_TaskId",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Submissions",
                newName: "TaskIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_TaskId",
                table: "Submissions",
                newName: "IX_Submissions_TaskIdId");

            migrationBuilder.AddColumn<int>(
                name: "TaskId1",
                table: "Submissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_TaskId1",
                table: "Submissions",
                column: "TaskId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Tasks_TaskId1",
                table: "Submissions",
                column: "TaskId1",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Tasks_TaskIdId",
                table: "Submissions",
                column: "TaskIdId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Tasks_TaskId1",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Tasks_TaskIdId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_TaskId1",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "TaskId1",
                table: "Submissions");

            migrationBuilder.RenameColumn(
                name: "TaskIdId",
                table: "Submissions",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_TaskIdId",
                table: "Submissions",
                newName: "IX_Submissions_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Tasks_TaskId",
                table: "Submissions",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
