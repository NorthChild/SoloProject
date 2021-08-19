using Microsoft.EntityFrameworkCore.Migrations;

namespace MasteryTrackedDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubSkill",
                columns: table => new
                {
                    SubSkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillID = table.Column<int>(type: "int", nullable: false),
                    SubSkillList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkill", x => x.SubSkillID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersID);
                });

            migrationBuilder.CreateTable(
                name: "SkillToMasters",
                columns: table => new
                {
                    SkillToMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    SubSkillID = table.Column<int>(type: "int", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotSkillHrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrYrHrs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PercToMast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstYrsToMast = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubSkillList = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillToMasters", x => x.SkillToMasterId);
                    table.ForeignKey(
                        name: "FK_SkillToMasters_SubSkill_SubSkillID",
                        column: x => x.SubSkillID,
                        principalTable: "SubSkill",
                        principalColumn: "SubSkillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillToMasters_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "UsersID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillToMasters_SubSkillID",
                table: "SkillToMasters",
                column: "SubSkillID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillToMasters_UsersID",
                table: "SkillToMasters",
                column: "UsersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillToMasters");

            migrationBuilder.DropTable(
                name: "SubSkill");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
