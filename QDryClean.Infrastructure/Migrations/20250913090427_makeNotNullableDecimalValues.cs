using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QDryClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class makeNotNullableDecimalValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "OrderInvoices",
                type: "decimal(6,0)",
                precision: 6,
                scale: 0,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,0)",
                oldPrecision: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "Customers",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "OrderInvoices",
                type: "decimal(6,0)",
                precision: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,0)",
                oldPrecision: 6,
                oldScale: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Points",
                table: "Customers",
                type: "decimal(6,2)",
                precision: 6,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldPrecision: 6,
                oldScale: 2);
        }
    }
}
