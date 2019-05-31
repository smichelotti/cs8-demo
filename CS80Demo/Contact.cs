using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS80Demo
{
    public class Contact
    {
        public string FirstName { get; set; }
        // C# 8.0: Nullable Reference Type
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Contact(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = null;
        }
    }

    public static class ContactService
    {
        public static IEnumerable<Contact> GetContacts()
        {
            yield return new Contact("Bill", "Gates") { MiddleName = "Henry" };
            yield return new Contact("Steve", "Ballmer") { MiddleName = "Anthony" };
            yield return new Contact("Satya", "Nadella");
        }
    }
}
