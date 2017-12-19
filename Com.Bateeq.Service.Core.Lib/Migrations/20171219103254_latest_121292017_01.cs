using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.Bateeq.Service.Core.Lib.Migrations
{
    public partial class latest_121292017_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    Uom = table.Column<string>(nullable: true),
                    _CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _CreatedUtc = table.Column<DateTime>(nullable: false),
                    _DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _DeletedUtc = table.Column<DateTime>(nullable: false),
                    _IsDeleted = table.Column<bool>(nullable: false),
                    _LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    _id = table.Column<string>(nullable: true),
                    _stamp = table.Column<string>(nullable: true),
                    _type = table.Column<string>(nullable: true),
                    _version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    ItemId = table.Column<int>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    Uom = table.Column<string>(nullable: true),
                    _CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _CreatedUtc = table.Column<DateTime>(nullable: false),
                    _DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _DeletedUtc = table.Column<DateTime>(nullable: false),
                    _IsDeleted = table.Column<bool>(nullable: false),
                    _LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    _LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    _id = table.Column<string>(nullable: true),
                    _stamp = table.Column<string>(nullable: true),
                    _type = table.Column<string>(nullable: true),
                    _version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Component_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Component_ItemId",
                table: "Component",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "Item");
        }
    }
}
