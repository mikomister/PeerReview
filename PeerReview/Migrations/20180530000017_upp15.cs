using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PeerReview.Migrations
{
    public partial class upp15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountInvites",
                table: "AspNetUsers",
                newName: "InvitesCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InvitesCount",
                table: "AspNetUsers",
                newName: "CountInvites");
        }
    }
}
