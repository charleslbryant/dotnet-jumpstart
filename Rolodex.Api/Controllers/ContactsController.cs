using Microsoft.AspNetCore.Mvc;
using Rolodex.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rolodex.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        // This is an in memory list of contacts that is reset everytime the controller is instantiated.
        // Normally, this would be a service that gets contacts form a database or another API that is injected in the constructor.
        private List<Contact> _contacts;
        
        // Normally, I'd expect to see dependencies injected into the controller for service, logging, etc.
        public ContactsController()
        {
            _contacts = LoadContacts(10);            
        }

        [HttpGet("{email}", Name = "GetContact")]
        public ActionResult<Contact> GetContact(string email)
        {
            // This type of logic would normally be included in an external service class that we inject in the constructor.
            var contact = _contacts.Where(x => x.Email == email)?.FirstOrDefault();
            return contact;
        }

        [HttpGet(Name = "GetContacts")]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            return _contacts;
        }

        [HttpGet("{id}", Name = "GetContactById")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contacts.Where(x => x.Id == id)?.FirstOrDefault();
            var result = new OkObjectResult(contact);
            return result;
        }


        // Here we are just loading the contacts list with dummy contacts in a loop that iterates "count" times.
        private List<Contact> LoadContacts(int count)
        {
            var contacts = new List<Contact>();

            for (int i = 1; i <= count; i++)
            {
                var contact = new Contact
                {
                    Id = i,
                    FirstName = $"TestFirstName{i}",
                    LastName = $"TestLastName{i}",
                    Email = $"test{i}@test{i}.com"
                };

                contacts.Add(contact);
            };

            return contacts;
        }
    }
}
