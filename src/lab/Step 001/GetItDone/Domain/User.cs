using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GetItDone.Domain
{
    public class User
    {
        private User()
        {
        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Roles = new Collection<UserRole>();
        }

        public int UserId { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<UserRole> Roles { get; private set; }

        public bool Is<T>() where T : UserRole
        {
            return Roles.OfType<T>().Any();
        }

        public T GetRole<T>() where T : UserRole
        {
            return Roles.OfType<T>().Single();
        }

        public void AddToRole<T>(T role) where T:UserRole
        {
            if (!Is<T>())
            {
                Roles.Add(role);
            }
        }

    }
}