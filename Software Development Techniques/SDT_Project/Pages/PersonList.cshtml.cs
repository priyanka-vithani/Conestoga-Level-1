using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonModel.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class PersonList : PageModel
{
    public List<Person> People { get; set; } = new();

    public void OnGet()
    {
        People = LoadPeopleFromJson();
    }

    // Load people from the JSON file
    private List<Person> LoadPeopleFromJson()
    {
        if (System.IO.File.Exists("People.json"))
        {
            var existingData = System.IO.File.ReadAllText("People.json");

            // Perform a null check before deserialization
            if (!string.IsNullOrEmpty(existingData))
            {
                return JsonSerializer.Deserialize<List<Person>>(existingData) ?? new List<Person>();
            }
        }
        return new List<Person>();
    }
}
