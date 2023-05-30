using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrupoClientes.ViewsModel
{
    public class MenuCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [Column("Descricao")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter no mínimo 4 caracteres "), MinLength(4)]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [Column("Url")]
        public String Url { get; set; }
    }

}
