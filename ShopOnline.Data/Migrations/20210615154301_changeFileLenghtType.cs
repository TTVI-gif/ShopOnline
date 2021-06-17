using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class changeFileLenghtType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "21800f14-3dda-4b50-bd41-e4322bfca385");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca6e7f28-5bc9-4e15-aed4-e1ef1a0d01cf", "AQAAAAEAACcQAAAAEKdndsDdf9xgr4cILUkng5oQS2QUAw+m8VlvpkWt5CKXShIrXNxF2qdSkdQlFtlwKQ==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 15, 22, 43, 0, 958, DateTimeKind.Local).AddTicks(7501));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3b3e0151-0dfc-4182-984d-02e694cdbde2");

            migrationBuilder.UpdateData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d117bcf7-c680-4498-ae40-9340504432f1", "AQAAAAEAACcQAAAAEKoQPYt9vDk4SscngtD6GevSRA8uBCST2GAvMa+vyS9dRUeiImizvXpwLB9FLRgxyA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 6, 15, 21, 42, 28, 610, DateTimeKind.Local).AddTicks(4793));
        }
    }
}
