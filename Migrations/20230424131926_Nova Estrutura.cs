using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoClientes.Migrations
{
    /// <inheritdoc />
    public partial class NovaEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupos_Menu");

            migrationBuilder.DropTable(
                name: "Usuario_Grupos");

            migrationBuilder.CreateTable(
                name: "GrupoMenu",
                columns: table => new
                {
                    ListaDeGruposId = table.Column<int>(type: "int", nullable: false),
                    ListaDeMenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoMenu", x => new { x.ListaDeGruposId, x.ListaDeMenusId });
                    table.ForeignKey(
                        name: "FK_GrupoMenu_Grupos_ListaDeGruposId",
                        column: x => x.ListaDeGruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoMenu_Menu_ListaDeMenusId",
                        column: x => x.ListaDeMenusId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    ListaDeGruposId = table.Column<int>(type: "int", nullable: false),
                    ListaDeUsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => new { x.ListaDeGruposId, x.ListaDeUsuariosId });
                    table.ForeignKey(
                        name: "FK_GrupoUsuario_Grupos_ListaDeGruposId",
                        column: x => x.ListaDeGruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoUsuario_Usuario_ListaDeUsariosId",
                        column: x => x.ListaDeUsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuUsuario",
                columns: table => new
                {
                    ListaDeUsuariosId = table.Column<int>(type: "int", nullable: false),
                    ListadeMenusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuUsuario", x => new { x.ListaDeUsuariosId, x.ListadeMenusId });
                    table.ForeignKey(
                        name: "FK_MenuUsuario_Menu_ListadeMenusId",
                        column: x => x.ListadeMenusId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuUsuario_Usuario_ListaDeUsuariosId",
                        column: x => x.ListaDeUsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_GrupoMenu_ListaDeMenusId",
                table: "GrupoMenu",
                column: "ListaDeMenusId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuario_ListaDeUsariosId",
                table: "GrupoUsuario",
                column: "ListaDeUsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuUsuario_ListadeMenusId",
                table: "MenuUsuario",
                column: "ListadeMenusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoMenu");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropTable(
                name: "MenuUsuario");

            migrationBuilder.CreateTable(
                name: "Grupos_Menu",
                columns: table => new
                {
                    GruposId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos_Menu", x => new { x.GruposId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_Grupos_Menu_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupos_Menu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Grupos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    GruposId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Grupos", x => new { x.GruposId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_Usuario_Grupos_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Grupos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Menu_MenuId",
                table: "Grupos_Menu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Grupos_UsuarioId",
                table: "Usuario_Grupos",
                column: "UsuarioId");
        }
    }
}
