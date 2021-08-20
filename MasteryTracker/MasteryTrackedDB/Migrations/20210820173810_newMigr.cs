using Microsoft.EntityFrameworkCore.Migrations;

namespace MasteryTrackedDB.Migrations
{
    public partial class newMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillToMasters_SubSkill_SubSkillID",
                table: "SkillToMasters");

            migrationBuilder.DropIndex(
                name: "IX_SkillToMasters_SubSkillID",
                table: "SkillToMasters");

            migrationBuilder.DropColumn(
                name: "SubSkillList",
                table: "SubSkill");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "SubSkill",
                newName: "SkillToMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkill_SkillToMasterId",
                table: "SubSkill",
                column: "SkillToMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSkill_SkillToMasters_SkillToMasterId",
                table: "SubSkill",
                column: "SkillToMasterId",
                principalTable: "SkillToMasters",
                principalColumn: "SkillToMasterId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSkill_SkillToMasters_SkillToMasterId",
                table: "SubSkill");

            migrationBuilder.DropIndex(
                name: "IX_SubSkill_SkillToMasterId",
                table: "SubSkill");

            migrationBuilder.RenameColumn(
                name: "SkillToMasterId",
                table: "SubSkill",
                newName: "SkillID");

            migrationBuilder.AddColumn<string>(
                name: "SubSkillList",
                table: "SubSkill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillToMasters_SubSkillID",
                table: "SkillToMasters",
                column: "SubSkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillToMasters_SubSkill_SubSkillID",
                table: "SkillToMasters",
                column: "SubSkillID",
                principalTable: "SubSkill",
                principalColumn: "SubSkillID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
