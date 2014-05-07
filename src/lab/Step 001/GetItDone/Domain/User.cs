using System.Collections.Generic;

namespace GetItDone.Domain
{
    public class User
    {
        public User()
        {
            
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserRole> Roles { get; set; }
    }
}