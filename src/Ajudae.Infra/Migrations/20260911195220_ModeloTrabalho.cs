using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ajudae.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ModeloTrabalho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Presencial",
                table: "Voluntarios");

            migrationBuilder.AddColumn<int>(
                name: "ModeloDeTrabalho",
                table: "Voluntarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloDeTrabalho",
                table: "Voluntarios");

            migrationBuilder.AddColumn<bool>(
                name: "Presencial",
                table: "Voluntarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
