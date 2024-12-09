using System.ComponentModel.DataAnnotations;

namespace ThesisMate.DTOs
{
    public record LoginDTO(
        [Required]
        string Email,
        [Required] 
        string Password
    );
}