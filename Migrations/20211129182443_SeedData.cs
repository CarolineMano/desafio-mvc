using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESAFIO.MVC.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dailies_Modules_ModuleId",
                table: "Dailies");

            migrationBuilder.DropForeignKey(
                name: "FK_Dailies_Starters_StarterId",
                table: "Dailies");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Technologies_TechnologyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Starters_StarterId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Starters_Groups_GroupId",
                table: "Starters");

            migrationBuilder.DropForeignKey(
                name: "FK_Starters_StartPrograms_StartProgramId",
                table: "Starters");

            migrationBuilder.AlterColumn<int>(
                name: "StartProgramId",
                table: "Starters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Starters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StarterId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TechnologyId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StarterId",
                table: "Dailies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Dailies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "849bb501-93c9-4b32-a86a-265f5d27a1be", 0, "43b71270-9b0c-4c07-b79d-adc7c843010b", "clecio.silva@gft.com", true, true, null, "CLECIO.SILVA@GFT.COM", "CLECIO.SILVA@GFT.COM", "AQAAAAEAACcQAAAAEF+HlcZRm9tLJC0NDcr32HCx39ffy9UpaHB+wUPWnCHeRlIQTljspfErGgZo0xW8gQ==", null, false, "a1bdbdbd-0626-4654-9643-031d7654d68e", false, "clecio.silva@gft.com" },
                    { "6eef2868-d9db-47a0-b23f-f512cf387390", 0, "ad81943b-252a-4ee7-85eb-0b1f61cf2785", "zezinho@gft.com", true, true, null, "ZEZINHO@GFT.COM", "ZEZINHO@GFT.COM", "AQAAAAEAACcQAAAAEFp+OhnRrTwoNJD4gAndvSFZv+j8WYo6I+WHvGn4Uvq15iEZAUtgP0TN/J4mmg+QSg==", null, false, "9f9b8ff9-f5ca-4880-bec0-fe2330d9286a", false, "zezinho@gft.com" },
                    { "b21c526c-5931-4e6c-bac9-d6e8977034cf", 0, "9fcd0bbe-96a0-48e8-9171-202cb090d618", "luisinho@gft.com", true, true, null, "LUISINHO@GFT.COM", "LUISINHO@GFT.COM", "AQAAAAEAACcQAAAAEHMMCnqFXpNjiQBbWkkFFvOj505sM/XCWYoo3xQ1pP9GK/99SKfPdsU9eFxFEZ0czw==", null, false, "2de79ee1-8450-434a-a36f-629d91439f98", false, "luisinho@gft.com" },
                    { "7a615f2c-dddc-4741-bc95-bf70ed616355", 0, "ae2a7edf-1570-4a58-bb83-ddebc30d2383", "huguinho@gft.com", true, true, null, "HUGUINHO@GFT.COM", "HUGUINHO@GFT.COM", "AQAAAAEAACcQAAAAEE1B2zfVsrqe6dueMLj+MSmu+31glL0qdoG2bMu/ecdoqvO7ZlJg4zXigiY/+ASwnw==", null, false, "4591966f-be8a-4108-b785-798c83ce3413", false, "huguinho@gft.com" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "MVC", true },
                    { 2, "API", true }
                });

            migrationBuilder.InsertData(
                table: "StartPrograms",
                columns: new[] { "Id", "EndDate", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turma 1", new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, new DateTime(2021, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turma 2", new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, ".NET with C# and Visual Studio Code", ".NET", true },
                    { 2, "No description available", "Java", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "FullName", "Clécio Silva", "849bb501-93c9-4b32-a86a-265f5d27a1be" },
                    { 2, "UserRole", "admin", "849bb501-93c9-4b32-a86a-265f5d27a1be" },
                    { 3, "FullName", "Zezinho", "6eef2868-d9db-47a0-b23f-f512cf387390" },
                    { 4, "UserRole", "scrumMaster", "6eef2868-d9db-47a0-b23f-f512cf387390" },
                    { 5, "FullName", "Luisinho", "b21c526c-5931-4e6c-bac9-d6e8977034cf" },
                    { 6, "UserRole", "scrumMaster", "b21c526c-5931-4e6c-bac9-d6e8977034cf" },
                    { 7, "FullName", "Huguinho", "7a615f2c-dddc-4741-bc95-bf70ed616355" },
                    { 8, "UserRole", "scrumMaster", "7a615f2c-dddc-4741-bc95-bf70ed616355" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "ScrumMaster", "Status", "TechnologyId" },
                values: new object[,]
                {
                    { 1, "Luisinho", true, 1 },
                    { 2, "Luisinho", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Starters",
                columns: new[] { "Id", "FourCharacters", "GroupId", "Name", "StartProgramId", "Status" },
                values: new object[] { 1, "PAMM", 1, "Pucca", 1, true });

            migrationBuilder.InsertData(
                table: "Starters",
                columns: new[] { "Id", "FourCharacters", "GroupId", "Name", "StartProgramId", "Status" },
                values: new object[] { 2, "MIMM", 2, "Mochi", 1, true });

            migrationBuilder.InsertData(
                table: "Dailies",
                columns: new[] { "Id", "Date", "Impediments", "ModuleId", "Presence", "StarterId", "Status", "TasksDoing", "TasksDone" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 11, 29, 15, 24, 43, 265, DateTimeKind.Local).AddTicks(75), "None", 1, 2, 1, true, "Authentication", "CRUD" },
                    { 2, new DateTime(2021, 11, 29, 15, 24, 43, 265, DateTimeKind.Local).AddTicks(2291), "None", 1, 2, 2, true, "Data seed", "Authentication" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Grade", "ModuleId", "StarterId", "Status" },
                values: new object[,]
                {
                    { 1, 10f, 1, 1, true },
                    { 2, 9f, 1, 2, true }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dailies_Modules_ModuleId",
                table: "Dailies",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dailies_Starters_StarterId",
                table: "Dailies",
                column: "StarterId",
                principalTable: "Starters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Technologies_TechnologyId",
                table: "Groups",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Starters_StarterId",
                table: "Projects",
                column: "StarterId",
                principalTable: "Starters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_Groups_GroupId",
                table: "Starters",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_StartPrograms_StartProgramId",
                table: "Starters",
                column: "StartProgramId",
                principalTable: "StartPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dailies_Modules_ModuleId",
                table: "Dailies");

            migrationBuilder.DropForeignKey(
                name: "FK_Dailies_Starters_StarterId",
                table: "Dailies");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Technologies_TechnologyId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Starters_StarterId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Starters_Groups_GroupId",
                table: "Starters");

            migrationBuilder.DropForeignKey(
                name: "FK_Starters_StartPrograms_StartProgramId",
                table: "Starters");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dailies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StartPrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6eef2868-d9db-47a0-b23f-f512cf387390");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a615f2c-dddc-4741-bc95-bf70ed616355");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "849bb501-93c9-4b32-a86a-265f5d27a1be");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b21c526c-5931-4e6c-bac9-d6e8977034cf");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Starters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Starters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StartPrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "StartProgramId",
                table: "Starters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Starters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StarterId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TechnologyId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StarterId",
                table: "Dailies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Dailies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Dailies_Modules_ModuleId",
                table: "Dailies",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dailies_Starters_StarterId",
                table: "Dailies",
                column: "StarterId",
                principalTable: "Starters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Technologies_TechnologyId",
                table: "Groups",
                column: "TechnologyId",
                principalTable: "Technologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Modules_ModuleId",
                table: "Projects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Starters_StarterId",
                table: "Projects",
                column: "StarterId",
                principalTable: "Starters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_Groups_GroupId",
                table: "Starters",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Starters_StartPrograms_StartProgramId",
                table: "Starters",
                column: "StartProgramId",
                principalTable: "StartPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
