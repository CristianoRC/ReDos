using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace ReDosApi.Controllers;

[ApiController]
[Route("[controller]")]
public class NewsletterController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] User user)
    {
        var emailIsValid = EmailAddressIsValid(user.Email);
        return emailIsValid ? Ok() : BadRequest(new { Message = "InvalidEmail" });
    }

    private static bool EmailAddressIsValid(string emailAddress)
    {
        const string emailAddressPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        //const string emailAddressPattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@(([0-9a-zA-Z])+([-\w]*[0-9a-zA-Z])*\.)+[azA-Z]{2,9})$";
        return Regex.IsMatch(emailAddress, emailAddressPattern, RegexOptions.None, TimeSpan.FromSeconds(10));
        //return Regex.IsMatch(emailAddress, emailAddressPattern);
    }
}
