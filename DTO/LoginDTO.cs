using System.ComponentModel.DataAnnotations;

namespace EventPlus_.DTO
{
    public class LoginDTO
    {

      

            [Required(ErrorMessage = "o email é obrigatorio!")]
            public string? Email { get; set; }


            [Required(ErrorMessage = "o senha é obrigatoria")]
            [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 caracteres e no maximo 60")]
            public string? Senha { get; set; }
         
    }
}
