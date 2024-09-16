using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transaction.Migrations
{
    /// <inheritdoc />
    public partial class RemadeTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_TransactionToCoupons_TransactionToCouponsId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_TransactionToCouponsId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionToCouponsId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "CouponsId",
                table: "TransactionToCoupons",
                newName: "Code");

            migrationBuilder.AddColumn<double>(
                name: "AmountOfDiscount",
                table: "TransactionToCoupons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "TransactionToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfDiscount",
                table: "TransactionToCoupons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionToCoupons_TransactionId",
                table: "TransactionToCoupons",
                column: "TransactionId");

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

            migrationBuilder.DropIndex(
                name: "IX_TransactionToCoupons_TransactionId",
                table: "TransactionToCoupons");

            migrationBuilder.DropColumn(
                name: "AmountOfDiscount",
                table: "TransactionToCoupons");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "TransactionToCoupons");

            migrationBuilder.DropColumn(
                name: "TypeOfDiscount",
                table: "TransactionToCoupons");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "TransactionToCoupons",
                newName: "CouponsId");

            migrationBuilder.AlterColumn<decimal>(
                name: "FinalPrice",
                table: "Transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionToCouponsId",
                table: "Transaction",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionToCouponsId",
                table: "Transaction",
                column: "TransactionToCouponsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_TransactionToCoupons_TransactionToCouponsId",
                table: "Transaction",
                column: "TransactionToCouponsId",
                principalTable: "TransactionToCoupons",
                principalColumn: "Id");
        }
    }
}
