using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoClientes.Models
{
    [Table("Grupos")]
    public class Grupo
    {
        public Grupo() 
        {
            ListaDeMenus = new List<Menu>();
            ListaDeUsuarios = new List<Usuario>();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public String Descricao { get; set; }

        public virtual ICollection<Usuario> ListaDeUsuarios { get; set; }

        public virtual ICollection<Menu> ListaDeMenus { get; set; }

    }
}
