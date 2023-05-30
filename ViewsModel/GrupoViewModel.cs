using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrupoClientes.ViewsModel
{
    public class GrupoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Column("Descricao")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no mínimo 4 caracteres "), MinLength(4)]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        public int IdMenu { get; set; }

        public int IdUsuario { get; set; }

        public List<UsuarioViewModel> Usuarios { get; set; }

        public List<UsuarioViewModel> UsuariosDisponiveis { get; set; }

        public List<MenuViewModel> Menus { get; set; }

        public List<MenuViewModel> MenusDisponiveis { get; set; }

    }
}
