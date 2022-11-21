using System.ComponentModel.DataAnnotations;

namespace MySongsWebApp.Models;

public class UserViewModel
{
    [Required]
    [StringLength(25)]
    public string FirstName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Cognome non valido")]
    [StringLength(50, MinimumLength = 3)]
    public string LastName { get; set; } = String.Empty;

    [Required]
    [EmailAddress]
    public string MailAddress { get; set; } = String.Empty;
}
