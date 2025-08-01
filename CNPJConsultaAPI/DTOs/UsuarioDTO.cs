using System.ComponentModel.DataAnnotations;

namespace CNPJConsultaAPI.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "Nome pode ter até 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(150, MinimumLength = 8, ErrorMessage = "Senha deve ter entre 8 e 150 caracteres")]
        public string Senha { get; set; }
    }
}
