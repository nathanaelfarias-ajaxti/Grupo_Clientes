using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoClientes.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public Usuario() 
        {
            ListaDeGrupos = new List<Grupo>();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Senha { get; set; }

        public String Email { get; set; }

        public virtual ICollection<Grupo> ListaDeGrupos { get; set; }
        public virtual ICollection<Menu> ListaDeMenus { get; set; }
    }
}
