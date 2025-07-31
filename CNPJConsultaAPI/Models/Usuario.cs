using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNPJConsultaAPI.Models
{

    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(150)]
        public string Senha { get; set; }

        public ICollection<Empresa> Empresas { get; set; }
    }
}
