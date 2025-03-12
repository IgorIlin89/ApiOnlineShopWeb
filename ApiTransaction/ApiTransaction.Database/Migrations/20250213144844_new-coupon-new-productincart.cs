using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Database.Migrations
{
    /// <inheritdoc />
    public partial class newcouponnewproductincart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionToCoupons_Transaction_TransactionId",
                table: "TransactionToCoupons");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "TransactionToCoupons");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TransactionToCoupons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionToCoupons_Transaction_TransactionId",
                table: "TransactionToCoupons",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionToCoupons_Transaction_TransactionId",
                table: "TransactionToCoupons");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TransactionToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "TransactionToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionToCoupons_Transaction_TransactionId",
                table: "TransactionToCoupons",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
