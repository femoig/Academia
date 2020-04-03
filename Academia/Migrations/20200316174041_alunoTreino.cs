using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Migrations
{
    public partial class alunoTreino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Treino_TreinoId",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_TreinoId",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "TreinoId",
                table: "Aluno");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Treino",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Treino_Aluno_Id",
                table: "Treino",
                column: "Id",
                principalTable: "Aluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treino_Aluno_Id",
                table: "Treino");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Treino",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TreinoId",
                table: "Aluno",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_TreinoId",
                table: "Aluno",
                column: "TreinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Treino_TreinoId",
                table: "Aluno",
                column: "TreinoId",
                principalTable: "Treino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
