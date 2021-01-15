using Rolodex.Web;
using Rolodex.Web.Controllers;
using Rolodex.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rolodex.Test
{
    public class ContactsControllerTest
    {
        // We create a variable to hold our system under test (sut) so we don't have to instantiate it in every test
        private ContactsController _sut;

        public ContactsControllerTest()
        {
            // We instantiate it once here then use it in all the tests
            // If the controller was injected with dependencies, we could use mocks (Moq is a good library for mocks)
            _sut = new ContactsController();
        }


        [Fact]
        public void GetContact()
        {
            var email = "test1@test1.com";
            var expected = "TestFirstName1";

            // The ActionResult is returned
            var result = _sut.GetContact(email);

            // We get the actual contact from the result
            Contact actual = result.Value;

            // We assert that we see the correct First Name
            // This isn't a good test, but since this is still pretty basic it is OK
            Assert.Equal(expected, actual.FirstName);
        }

        [Fact]
        public void GetContacts()
        {
            var expected = 10;

            var result = _sut.GetContacts();

            IEnumerable<Contact> actual = result.Value;

            Assert.Equal(expected, actual.Count());
        }
    }
}
