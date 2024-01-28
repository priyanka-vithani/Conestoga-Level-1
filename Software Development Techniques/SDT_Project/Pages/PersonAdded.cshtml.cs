using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonModel.Models;
public class PersonAdded :PageModel{
    public Person person = new Person();
    //Get Submitted Persion information
    public void OnGet(Person _person)
    {
            this.person = _person;
        
    }
}