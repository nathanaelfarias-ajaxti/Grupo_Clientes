using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrupoClientes.ViewsModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required]
        [Column("Nome")]
        [MaxLength(50, ErrorMessage = "Este campo deve conter no mínimo 7 caracteres "), MinLength(7)]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Required]
        [Column("Senha")]
        [MaxLength(12, ErrorMessage = "Este campo deve conter no mínimo 8 caracteres "), MinLength(8)]
        [Display(Name = "Senha")]
        public String Senha { get; set; }

        [Column("Email")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no mínimo 10 caracteres "), MinLength(10)]
        [Display(Name = "Email")]
        public String Email { get; set; }

        public int IdGrupo { get; set; }

        public List<GrupoViewModel> Grupos { get; set; }

        public List<GrupoViewModel> GruposDisponiveis { get; set; }
    }
}
