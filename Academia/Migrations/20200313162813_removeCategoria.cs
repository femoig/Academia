using Microsoft.EntityFrameworkCore.Migrations;

namespace Academia.Migrations
{
    public partial class removeCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Exercicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Exercicio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
