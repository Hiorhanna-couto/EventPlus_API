using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid UsuarioID { get; set; }



        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do usuário é obrigatório!")]
        public string? NomeUsuario { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }



        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O tipo usuário é obrigatório!")]
        public Guid TipoUsuarioID { get; set; }

        [ForeignKey("TipoUsuarioID")]
        public TipoUsuario? TipoUsuarios{ get; set; }

    }
}
