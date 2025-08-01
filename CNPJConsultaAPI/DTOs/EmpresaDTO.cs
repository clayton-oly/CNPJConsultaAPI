using System.ComponentModel.DataAnnotations;

namespace CNPJConsultaAPI.DTO
{
    public class EmpresaDTO
    {
        [Required(ErrorMessage = "Nome empresarial é obrigatório.")]
        [StringLength(200)]
        public string NomeEmpresarial { get; set; } = null!;

        [Required(ErrorMessage = "Nome fantasia é obrigatório.")]
        [StringLength(200)]
        public string NomeFantasia { get; set; } = null!;

        [Required(ErrorMessage = "CNPJ é obrigatório.")]
        [StringLength(20)]
        public string Cnpj { get; set; } = null!;

        [StringLength(50)]
        public string? Situacao { get; set; }

        [StringLength(20)]
        public string? Abertura { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; }

        [StringLength(200)]
        public string? NaturezaJuridica { get; set; }

        [StringLength(500)]
        public string? AtividadePrincipal { get; set; }

        [StringLength(200)]
        public string? Logradouro { get; set; }

        [StringLength(20)]
        public string? Numero { get; set; }

        [StringLength(100)]
        public string? Complemento { get; set; }

        [StringLength(100)]
        public string? Bairro { get; set; }

        [StringLength(100)]
        public string? Municipio { get; set; }

        [StringLength(2)]
        public string? Uf { get; set; }

        [StringLength(10)]
        public string? Cep { get; set; }
    }
}
