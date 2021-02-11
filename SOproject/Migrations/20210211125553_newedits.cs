using Microsoft.EntityFrameworkCore.Migrations;

namespace SOproject.Migrations
{
    public partial class newedits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOLines_SalesOrder_SalesOrderId",
                table: "SOLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SOLines",
                table: "SOLines");

            migrationBuilder.DropIndex(
                name: "IX_SOLines_SalesOrderId",
                table: "SOLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SOLines");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "SOLines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SalesOrder");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "SOLines",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobNumber",
                table: "SOLines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SalesOrderNumber",
                table: "SOLines",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "SalesOrder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SOLines",
                table: "SOLines",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_SOLines_SalesOrderNumber",
                table: "SOLines",
                column: "SalesOrderNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_SOLines_SalesOrder_SalesOrderNumber",
                table: "SOLines",
                column: "SalesOrderNumber",
                principalTable: "SalesOrder",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOLines_SalesOrder_SalesOrderNumber",
                table: "SOLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SOLines",
                table: "SOLines");

            migrationBuilder.DropIndex(
                name: "IX_SOLines_SalesOrderNumber",
                table: "SOLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "SOLines");

            migrationBuilder.DropColumn(
                name: "JobNumber",
                table: "SOLines");

            migrationBuilder.DropColumn(
                name: "SalesOrderNumber",
                table: "SOLines");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SOLines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderId",
                table: "SOLines",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "SalesOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SalesOrder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SOLines",
                table: "SOLines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesOrder",
                table: "SalesOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SOLines_SalesOrderId",
                table: "SOLines",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SOLines_SalesOrder_SalesOrderId",
                table: "SOLines",
                column: "SalesOrderId",
                principalTable: "SalesOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
