using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Task2.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MgrDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mgrSSN = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DNumber);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Minit = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    BDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    superSSN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Dnum = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "DNumber");
                    table.ForeignKey(
                        name: "FK_Employees_Employees_superSSN",
                        column: x => x.superSSN,
                        principalTable: "Employees",
                        principalColumn: "SSN");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Dnum = table.Column<long>(type: "bigint", nullable: false),
                    locations = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => new { x.Dnum, x.locations });
                    table.ForeignKey(
                        name: "FK_Locations_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "DNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PNum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dnum = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PNum);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_Dnum",
                        column: x => x.Dnum,
                        principalTable: "Departments",
                        principalColumn: "DNumber");
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ESSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => new { x.Name, x.ESSN });
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    ESSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pnum = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    hour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => new { x.ESSN, x.Pnum });
                    table.ForeignKey(
                        name: "FK_Works_Employees_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employees",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Works_Projects_Pnum",
                        column: x => x.Pnum,
                        principalTable: "Projects",
                        principalColumn: "PNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_mgrSSN",
                table: "Departments",
                column: "mgrSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_ESSN",
                table: "Dependents",
                column: "ESSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Dnum",
                table: "Employees",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_superSSN",
                table: "Employees",
                column: "superSSN");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Dnum",
                table: "Projects",
                column: "Dnum");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Pnum",
                table: "Works",
                column: "Pnum");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_mgrSSN",
                table: "Departments",
                column: "mgrSSN",
                principalTable: "Employees",
                principalColumn: "SSN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_mgrSSN",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
