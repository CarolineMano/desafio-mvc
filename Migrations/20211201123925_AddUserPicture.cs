using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESAFIO.MVC.Migrations
{
    public partial class AddUserPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Starters",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6eef2868-d9db-47a0-b23f-f512cf387390",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51248104-1591-4082-b0c1-5c0bcd858055", "AQAAAAEAACcQAAAAEJcDc5RdQ5LgLHcj6u50sV11Jk2g4zE8DO+grFUuKWlDgEbKFO0y/foLzcBgrZKJ+Q==", "3af93b65-0931-489c-a702-5f22da646ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a615f2c-dddc-4741-bc95-bf70ed616355",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af22c01-84cb-49f4-8a15-e5e71765da83", "AQAAAAEAACcQAAAAEI1+gzmEaUv0s+3yqMUAX38JllArrq9DlUBI3G8Rb/KnSXDvmCfEUkmJCRQ6VH4ejw==", "f46cc96b-3126-41a8-bf6e-8f0016fc0e13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "849bb501-93c9-4b32-a86a-265f5d27a1be",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90dfc649-8648-4500-92d7-5e9b3336e06a", "AQAAAAEAACcQAAAAEGAJkMMpaFpbllIcoSX1Ymx/DU+gN2EekAWm96lzrZKCOYQ5MhH9x1Z8SltqS9NdBQ==", "83784aac-231d-4349-ab48-802635733a52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21c526c-5931-4e6c-bac9-d6e8977034cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "946693d4-049d-4a28-ac7c-590b9e3cb562", "AQAAAAEAACcQAAAAEGSpVT4ePeykSGPvsGbJIX7W96jjX56JqaS93b6A8fSpBgTB8tMhqR/LL5mfLUqT3w==", "7942f6a8-5042-4a8f-af9d-9fd1c55f96a2" });

            migrationBuilder.UpdateData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 1, 9, 39, 24, 614, DateTimeKind.Local).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 12, 1, 9, 39, 24, 615, DateTimeKind.Local).AddTicks(1309));

            migrationBuilder.UpdateData(
                table: "Starters",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "IMG_20201112_130915.jpg");

            migrationBuilder.UpdateData(
                table: "Starters",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "IMG_20211116_162601.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Starters");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6eef2868-d9db-47a0-b23f-f512cf387390",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad81943b-252a-4ee7-85eb-0b1f61cf2785", "AQAAAAEAACcQAAAAEFp+OhnRrTwoNJD4gAndvSFZv+j8WYo6I+WHvGn4Uvq15iEZAUtgP0TN/J4mmg+QSg==", "9f9b8ff9-f5ca-4880-bec0-fe2330d9286a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a615f2c-dddc-4741-bc95-bf70ed616355",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae2a7edf-1570-4a58-bb83-ddebc30d2383", "AQAAAAEAACcQAAAAEE1B2zfVsrqe6dueMLj+MSmu+31glL0qdoG2bMu/ecdoqvO7ZlJg4zXigiY/+ASwnw==", "4591966f-be8a-4108-b785-798c83ce3413" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "849bb501-93c9-4b32-a86a-265f5d27a1be",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43b71270-9b0c-4c07-b79d-adc7c843010b", "AQAAAAEAACcQAAAAEF+HlcZRm9tLJC0NDcr32HCx39ffy9UpaHB+wUPWnCHeRlIQTljspfErGgZo0xW8gQ==", "a1bdbdbd-0626-4654-9643-031d7654d68e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21c526c-5931-4e6c-bac9-d6e8977034cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fcd0bbe-96a0-48e8-9171-202cb090d618", "AQAAAAEAACcQAAAAEHMMCnqFXpNjiQBbWkkFFvOj505sM/XCWYoo3xQ1pP9GK/99SKfPdsU9eFxFEZ0czw==", "2de79ee1-8450-434a-a36f-629d91439f98" });

            migrationBuilder.UpdateData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 11, 29, 15, 24, 43, 265, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 11, 29, 15, 24, 43, 265, DateTimeKind.Local).AddTicks(2291));
        }
    }
}
