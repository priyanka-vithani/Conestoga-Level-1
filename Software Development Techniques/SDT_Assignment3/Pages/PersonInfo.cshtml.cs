using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonModel.Models;
using Microsoft.AspNetCore.Http.Metadata;

public class PersonInfo : PageModel
{
    private readonly HttpClient ClientRequest = new();

    public Person person { get; set; } = new();
    
    // Action for handling form submission
    public IActionResult OnPost(Person prson)
    {
        return RedirectToPage("PersonAdded", prson);
    }
}
