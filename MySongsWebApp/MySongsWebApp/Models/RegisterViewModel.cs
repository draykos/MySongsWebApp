using System.ComponentModel.DataAnnotations;

namespace MySongsWebApp.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = String.Empty;

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Conferma la password")]
    [Compare("Password", ErrorMessage = "Le password non sono uguali")]
    public string ConfirmPassword { get; set; } = String.Empty;
}