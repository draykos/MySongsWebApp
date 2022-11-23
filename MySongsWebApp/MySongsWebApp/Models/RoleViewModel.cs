using System.ComponentModel.DataAnnotations;

namespace MySongsWebApp.Models;

public class RoleViewModel
{
    [Required]
    [StringLength(25)]
    public string RoleName{ get; set; } = String.Empty;

}
