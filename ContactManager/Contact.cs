using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact
    {
        int Id { get; set; }
        String Title { get; set; }
        String FirstName { get; set; }
        String LastName { get; set; }
        String MiddleName { get; set; }
        Boolean Gender { get; set; }
        String CreationDate { get; set; }
        String UpdateDate { get; set; }
        Boolean Active { get; set; }

        public Contact(int id, string title, string firstName, string lastName, string middleName, bool gender, string creationDate, string updateDate, bool active)
        {
            Id = id;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Gender = gender;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            Active = active;
        }
    }
}
