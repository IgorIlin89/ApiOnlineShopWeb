using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTransactionHistory.Migrations
{
    /// <inheritdoc />
    public partial class RemadeTransactionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_TransactionHistoryToCoupons_TransactionHistoryToCouponsId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_TransactionHistoryToCouponsId",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "TransactionHistoryToCouponsId",
                table: "TransactionHistory");

            migrationBuilder.RenameColumn(
                name: "CouponsId",
                table: "TransactionHistoryToCoupons",
                newName: "Code");

            migrationBuilder.AddColumn<double>(
                name: "AmountOfDiscount",
                table: "TransactionHistoryToCoupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "TransactionHistoryToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDiscount",
                table: "TransactionHistoryToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "TransactionHistory",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistoryToCoupons_TransactionHistoryId",
                table: "TransactionHistoryToCoupons",
                column: "TransactionHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistoryToCoupons_TransactionHistory_TransactionHistoryId",
                table: "TransactionHistoryToCoupons",
                column: "TransactionHistoryId",
                principalTable: "TransactionHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistoryToCoupons_TransactionHistory_TransactionHistoryId",
                table: "TransactionHistoryToCoupons");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistoryToCoupons_TransactionHistoryId",
                table: "TransactionHistoryToCoupons");

            migrationBuilder.DropColumn(
                name: "AmountOfDiscount",
                table: "TransactionHistoryToCoupons");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "TransactionHistoryToCoupons");

            migrationBuilder.DropColumn(
                name: "TypeOfDiscount",
                table: "TransactionHistoryToCoupons");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "TransactionHistoryToCoupons",
                newName: "CouponsId");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "TransactionHistory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionHistoryToCouponsId",
                table: "TransactionHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_TransactionHistoryToCouponsId",
                table: "TransactionHistory",
                column: "TransactionHistoryToCouponsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_TransactionHistoryToCoupons_TransactionHistoryToCouponsId",
                table: "TransactionHistory",
                column: "TransactionHistoryToCouponsId",
                principalTable: "TransactionHistoryToCoupons",
                principalColumn: "Id");
        }
    }
}
