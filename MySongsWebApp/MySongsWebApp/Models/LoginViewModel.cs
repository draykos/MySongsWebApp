using System.ComponentModel.DataAnnotations;

namespace MySongsWebApp.Models;

public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = String.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = String.Empty;

    public Boolean RememberMe { get; set; } = false;

}

