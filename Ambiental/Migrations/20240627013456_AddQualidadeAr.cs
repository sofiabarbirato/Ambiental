using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambiental.Migrations
{
    /// <inheritdoc />
    public partial class AddQualidadeAr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QUALIDADEAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IndiceQualidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataLeitura = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUALIDADEAR", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QUALIDADEAR_Id",
                table: "QUALIDADEAR",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QUALIDADEAR");
        }
    }
}
