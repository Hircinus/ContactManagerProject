using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    public class Contact
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public Boolean Gender { get; set; }
        public String CreationDate { get; set; }
        public String UpdateDate { get; set; }
        public Boolean Active { get; set; }

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
