using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Com.DanLiris.Service.Core.Lib.Migrations
{
    public partial class change_name_moduledestination_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleDesstinations_Modules_ModuleId",
                table: "ModuleDesstinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleDesstinations",
                table: "ModuleDesstinations");

            migrationBuilder.RenameTable(
                name: "ModuleDesstinations",
                newName: "ModuleDestinations");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleDesstinations_ModuleId",
                table: "ModuleDestinations",
                newName: "IX_ModuleDestinations_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleDestinations",
                table: "ModuleDestinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleDestinations_Modules_ModuleId",
                table: "ModuleDestinations",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModuleDestinations_Modules_ModuleId",
                table: "ModuleDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModuleDestinations",
                table: "ModuleDestinations");

            migrationBuilder.RenameTable(
                name: "ModuleDestinations",
                newName: "ModuleDesstinations");

            migrationBuilder.RenameIndex(
                name: "IX_ModuleDestinations_ModuleId",
                table: "ModuleDesstinations",
                newName: "IX_ModuleDesstinations_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModuleDesstinations",
                table: "ModuleDesstinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleDesstinations_Modules_ModuleId",
                table: "ModuleDesstinations",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
