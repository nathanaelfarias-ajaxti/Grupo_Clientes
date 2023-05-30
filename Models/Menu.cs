using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoClientes.Models
{
    [Table("Menu")]
    public class Menu
    {
        public Menu()
        {
            ListaDeGrupos = new List<Grupo>();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public String Descricao { get; set; }

        public String Url { get; set; }

        public virtual ICollection<Grupo> ListaDeGrupos { get; set; }
        public virtual ICollection<Usuario> ListaDeUsuarios { get; set; }
    }
}
