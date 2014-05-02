using System.Collections.Generic;
using System.Linq;

namespace GetItDone.Domain
{
    public class User
    {
        public User()
        {
            Roles = new List<UserRole>();    
        }

        public int UserId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual IEnumerable<UserRole> Roles { get; private set; }

        public bool Is<T>() where T : UserRole
        {
            return Roles.OfType<T>().Any();
        }

        public T GetRole<T>() where T : UserRole
        {
            return Roles.OfType<T>().Single();
        }

        // TODO-HH: add/remove roles
    }
}