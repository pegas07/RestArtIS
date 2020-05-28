using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Migrations
{
    public partial class AddBusinessPartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPartner",
                columns: table => new
                {
                    BusinessPartnerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartner", x => x.BusinessPartnerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPartner");
        }
    }
}
