using System;
using System.ComponentModel.DataAnnotations;

namespace Rolodex.Web.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
