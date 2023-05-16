using System.ComponentModel.DataAnnotations;

namespace 4GLCuadroDeMandoGarum.Model

{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
