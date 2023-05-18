using System.ComponentModel.DataAnnotations;

namespace _4GLCuadroDeMandoRevisionDeFicherosGarum.Model
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
