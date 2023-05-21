using System.ComponentModel.DataAnnotations;


namespace _4GLCuadroDeMandoRevisionDeAjustesGarum.Model
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
