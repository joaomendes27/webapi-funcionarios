using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFuncionario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Funcionario");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Funcionario");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
