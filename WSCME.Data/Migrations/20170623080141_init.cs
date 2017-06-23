using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WSCME.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrainingCentreCategorys",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCentreCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCentreTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Desc = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCentreTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCentres",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    LinkMain = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCentres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCentres_TrainingCentreCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TrainingCentreCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingCentres_TrainingCentreTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TrainingCentreTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCentres_CategoryId",
                table: "TrainingCentres",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCentres_TypeId",
                table: "TrainingCentres",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrainingCentres");

            migrationBuilder.DropTable(
                name: "TrainingCentreCategorys");

            migrationBuilder.DropTable(
                name: "TrainingCentreTypes");
        }
    }
}
