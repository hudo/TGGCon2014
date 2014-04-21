using System.Collections.Generic;
using System.Linq;

namespace GetItDone.Domain
{
    public class User
    {
        public int Id { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserRole> Roles { get; private set; }

        public bool Is<T>() where T : UserRole
        {
            return Roles.OfType<T>().Any();
        }

        public T GetRole<T>() where T : UserRole
        {
            return Roles.OfType<T>().Single();
        }
    }
}