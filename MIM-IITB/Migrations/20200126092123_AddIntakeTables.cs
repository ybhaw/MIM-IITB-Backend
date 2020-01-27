using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MIM_IITB.Migrations
{
    public partial class AddIntakeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Foods");

            migrationBuilder.AddColumn<bool>(
                name: "Expirable",
                table: "Foods",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalValue",
                table: "Foods",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                table: "Foods",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FoodTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Expirable = table.Column<bool>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodTypes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntakeBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    TotalBill = table.Column<decimal>(nullable: false),
                    Settled = table.Column<bool>(nullable: false),
                    SettleDate = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntakeBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntakeBatches_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intakes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    FoodTypeId = table.Column<Guid>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: true),
                    VendorId = table.Column<Guid>(nullable: true),
                    BoughtOn = table.Column<DateTime>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    LeftQuantity = table.Column<decimal>(nullable: false),
                    IntakeBatchId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intakes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Intakes_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intakes_FoodTypes_FoodTypeId",
                        column: x => x.FoodTypeId,
                        principalTable: "FoodTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intakes_IntakeBatches_IntakeBatchId",
                        column: x => x.IntakeBatchId,
                        principalTable: "IntakeBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intakes_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_VendorId",
                table: "Foods",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTypes_FoodId",
                table: "FoodTypes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_IntakeBatches_VendorId",
                table: "IntakeBatches",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Intakes_FoodId",
                table: "Intakes",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Intakes_FoodTypeId",
                table: "Intakes",
                column: "FoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Intakes_IntakeBatchId",
                table: "Intakes",
                column: "IntakeBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Intakes_VendorId",
                table: "Intakes",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Vendors_VendorId",
                table: "Foods",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Vendors_VendorId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Intakes");

            migrationBuilder.DropTable(
                name: "FoodTypes");

            migrationBuilder.DropTable(
                name: "IntakeBatches");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Foods_VendorId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Expirable",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
