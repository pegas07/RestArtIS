using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestArtIS.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrice",
                columns: table => new
                {
                    ItemPriceId = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(type: "money", nullable: true),
                    Currency = table.Column<string>(maxLength: 50, nullable: true),
                    VatVId = table.Column<Guid>(nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrice", x => x.ItemPriceId);
                });

            migrationBuilder.CreateTable(
                name: "PriceCategory",
                columns: table => new
                {
                    PriceCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Note = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceCategory", x => x.PriceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "RestArtItemCategory",
                columns: table => new
                {
                    RestArtItemCategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestArtItemCategory", x => x.RestArtItemCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Vat",
                columns: table => new
                {
                    VatId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Rate = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ValidTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValueId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vat", x => x.VatId);
                });

            migrationBuilder.CreateTable(
                name: "Parlor",
                columns: table => new
                {
                    ParlorId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parlor", x => x.ParlorId);
                    table.ForeignKey(
                        name: "FK_Parlor_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestArtItem",
                columns: table => new
                {
                    RestArtItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Descrip = table.Column<string>(maxLength: 500, nullable: true),
                    Alergens = table.Column<string>(maxLength: 50, nullable: true),
                    ItemCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestArtItem", x => x.RestArtItemId);
                    table.ForeignKey(
                        name: "FK_RestArtItem_RestArtItemCategory",
                        column: x => x.ItemCategoryId,
                        principalTable: "RestArtItemCategory",
                        principalColumn: "RestArtItemCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    MenuType = table.Column<short>(nullable: false),
                    ParlorId = table.Column<Guid>(nullable: true),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: true),
                    DateTo = table.Column<DateTime>(type: "date", nullable: true),
                    VisibleFrom = table.Column<DateTime>(type: "datetime", nullable: true),
                    VisibleTo = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menu_Parlor",
                        column: x => x.ParlorId,
                        principalTable: "Parlor",
                        principalColumn: "ParlorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ParlorId",
                table: "Menu",
                column: "ParlorId");

            migrationBuilder.CreateIndex(
                name: "IX_Parlor_CompanyId",
                table: "Parlor",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RestArtItem_ItemCategoryId",
                table: "RestArtItem",
                column: "ItemCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPrice");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "PriceCategory");

            migrationBuilder.DropTable(
                name: "RestArtItem");

            migrationBuilder.DropTable(
                name: "Vat");

            migrationBuilder.DropTable(
                name: "Parlor");

            migrationBuilder.DropTable(
                name: "RestArtItemCategory");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
