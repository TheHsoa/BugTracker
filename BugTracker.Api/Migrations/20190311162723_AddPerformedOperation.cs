using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Storage.Migrations
{
    public partial class AddPerformedOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Audit");

            migrationBuilder.CreateTable(
                name: "PerformedOperation",
                schema: "Audit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperationId = table.Column<long>(nullable: false),
                    PerformedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityChange",
                schema: "Audit",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PerformedOperationId = table.Column<long>(nullable: false),
                    EntityType = table.Column<long>(nullable: false),
                    EntityId = table.Column<long>(nullable: false),
                    Property = table.Column<string>(nullable: false),
                    OriginalValue = table.Column<string>(nullable: true),
                    ModifiedValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityChange_PerformedOperation_PerformedOperationId",
                        column: x => x.PerformedOperationId,
                        principalSchema: "Audit",
                        principalTable: "PerformedOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityChange_PerformedOperationId",
                schema: "Audit",
                table: "EntityChange",
                column: "PerformedOperationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityChange",
                schema: "Audit");

            migrationBuilder.DropTable(
                name: "PerformedOperation",
                schema: "Audit");
        }
    }
}
