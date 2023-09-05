#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace LoginParty.Models;

public class Login
{
    [MinLength(2,ErrorMessage = "Your Name Must be 2 characters long")]
    public string Name { get; set; }
}