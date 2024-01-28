using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonModel.Models;
using Microsoft.AspNetCore.Http.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;

public class PersonInfo : PageModel
{
    // Action for handling form submission
    public IActionResult OnPost(Person prson)
    {
        // Save Person object to JSON file
        SavePersonInformationToJson(prson);

        // Redirect to PersonList page
        return RedirectToPage("PersonList");
    }

    private void SavePersonInformationToJson(Person person)
    {
        var peopleList = new List<Person>();

        // Load people from the JSON file
        if (System.IO.File.Exists("People.json"))
        {
            var existingData = System.IO.File.ReadAllText("People.json");
            peopleList = JsonSerializer.Deserialize<List<Person>>(existingData);
        }

        // Add person to the JSON File
        if (peopleList != null)
        {
            peopleList.Add(person);
        }

        // Save the updated list to the JSON file
        var jsonData = JsonSerializer.Serialize(
            peopleList,
            new JsonSerializerOptions { WriteIndented = true }
        );
        System.IO.File.WriteAllText("People.json", jsonData);
    }
}
