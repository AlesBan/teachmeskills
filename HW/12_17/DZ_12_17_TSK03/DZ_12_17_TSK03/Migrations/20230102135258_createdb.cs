using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DZ_12_17_TSK03.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportSpecialists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSpecialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportSpecialists_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestTheme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SpecialistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRequests_SupportSpecialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "SupportSpecialists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("caa30ba3-db91-492d-8d33-8bf4a984d854"), "AmogusDepartment" },
                    { new Guid("85ccd314-2969-4bcd-9ffd-fc973c04c1d8"), "ImposterDepartment" },
                    { new Guid("b5828a73-67a6-4808-ab64-85a85a5d4e76"), "NormalDepartment" }
                });

            migrationBuilder.InsertData(
                table: "SupportSpecialists",
                columns: new[] { "Id", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { new Guid("f445e6de-8cec-43a5-8b10-f0b4b13d1285"), new Guid("caa30ba3-db91-492d-8d33-8bf4a984d854"), "Ales" },
                    { new Guid("77822d0e-fcb3-4d29-90da-7fc959094014"), new Guid("caa30ba3-db91-492d-8d33-8bf4a984d854"), "Martin" },
                    { new Guid("0eb57f05-17c2-4424-a707-3a1e7bef9404"), new Guid("caa30ba3-db91-492d-8d33-8bf4a984d854"), "Arseniy" },
                    { new Guid("f3cfb186-2a14-42fe-a0bd-ca896fe1a237"), new Guid("85ccd314-2969-4bcd-9ffd-fc973c04c1d8"), "Amogus" },
                    { new Guid("98081bbb-0dc2-447c-8a6d-6a6db4fd3448"), new Guid("85ccd314-2969-4bcd-9ffd-fc973c04c1d8"), "Abobus" },
                    { new Guid("186f6ada-621e-4f8f-91b7-a63402dec208"), new Guid("85ccd314-2969-4bcd-9ffd-fc973c04c1d8"), "Autobus" },
                    { new Guid("388f177f-816c-46a6-a180-f3f2f00fa270"), new Guid("b5828a73-67a6-4808-ab64-85a85a5d4e76"), "Ivan" },
                    { new Guid("e9e8c7e7-0ac8-409d-bff9-edcf482f06a2"), new Guid("b5828a73-67a6-4808-ab64-85a85a5d4e76"), "Dima" },
                    { new Guid("ddb16822-26a1-4d25-b47c-5e18d75350eb"), new Guid("b5828a73-67a6-4808-ab64-85a85a5d4e76"), "OLeg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupportRequests_SpecialistId",
                table: "SupportRequests",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSpecialists_DepartmentId",
                table: "SupportSpecialists",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "SupportSpecialists");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
