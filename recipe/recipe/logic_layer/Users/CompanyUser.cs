using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic_layer.Users
{
    public class CompanyUser : User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Bsn { get; private set; }
        public string Gender { get; private set; }
        public DateTime Birthdate { get; private set; }

        public CompanyUser(int id, string role, string username, string hashedPassword, string salt,
                           string email, string firstName, string lastName, int bsn, string gender, DateTime birthdate)
            : base(id, role, username, hashedPassword, salt, email)
        {
            FirstName = firstName;
            LastName = lastName;
            Bsn = bsn;
            Gender = gender;
            Birthdate = birthdate;
        }
    }
}
