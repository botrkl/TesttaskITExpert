using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesttaskITExpert.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Make_All_Ids_AutoIncrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "0, 1");
            
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Films",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "0, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FilmCategories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:Identity", "0, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Films",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:Identity", "0, 1");
        }
    }
}
