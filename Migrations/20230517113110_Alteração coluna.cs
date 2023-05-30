using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoClientes.Migrations
{
    /// <inheritdoc />
    public partial class Alteraçãocoluna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUsuario_Usuario_ListaDeUsariosId",
                table: "GrupoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUsuario_Menu_ListadeMenusId",
                table: "MenuUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuUsuario",
                table: "MenuUsuario");

            migrationBuilder.DropIndex(
                name: "IX_MenuUsuario_ListadeMenusId",
                table: "MenuUsuario");

            migrationBuilder.RenameColumn(
                name: "ListadeMenusId",
                table: "MenuUsuario",
                newName: "ListaDeMenusId");

            migrationBuilder.RenameColumn(
                name: "ListaDeUsariosId",
                table: "GrupoUsuario",
                newName: "ListaDeUsuariosId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoUsuario_ListaDeUsariosId",
                table: "GrupoUsuario",
                newName: "IX_GrupoUsuario_ListaDeUsuariosId");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuUsuario",
                table: "MenuUsuario",
                columns: new[] { "ListaDeMenusId", "ListaDeUsuariosId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuUsuario_ListaDeUsuariosId",
                table: "MenuUsuario",
                column: "ListaDeUsuariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUsuario_Usuario_ListaDeUsuariosId",
                table: "GrupoUsuario",
                column: "ListaDeUsuariosId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUsuario_Menu_ListaDeMenusId",
                table: "MenuUsuario",
                column: "ListaDeMenusId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrupoUsuario_Usuario_ListaDeUsuariosId",
                table: "GrupoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUsuario_Menu_ListaDeMenusId",
                table: "MenuUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuUsuario",
                table: "MenuUsuario");

            migrationBuilder.DropIndex(
                name: "IX_MenuUsuario_ListaDeUsuariosId",
                table: "MenuUsuario");

            migrationBuilder.RenameColumn(
                name: "ListaDeMenusId",
                table: "MenuUsuario",
                newName: "ListadeMenusId");

            migrationBuilder.RenameColumn(
                name: "ListaDeUsuariosId",
                table: "GrupoUsuario",
                newName: "ListaDeUsariosId");

            migrationBuilder.RenameIndex(
                name: "IX_GrupoUsuario_ListaDeUsuariosId",
                table: "GrupoUsuario",
                newName: "IX_GrupoUsuario_ListaDeUsariosId");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuario",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuario",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Menu",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Grupos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuUsuario",
                table: "MenuUsuario",
                columns: new[] { "ListaDeUsuariosId", "ListadeMenusId" });

            migrationBuilder.CreateIndex(
                name: "IX_MenuUsuario_ListadeMenusId",
                table: "MenuUsuario",
                column: "ListadeMenusId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrupoUsuario_Usuario_ListaDeUsariosId",
                table: "GrupoUsuario",
                column: "ListaDeUsariosId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUsuario_Menu_ListadeMenusId",
                table: "MenuUsuario",
                column: "ListadeMenusId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
