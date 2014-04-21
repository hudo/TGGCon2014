using System.Collections.Generic;

namespace GetItDone.Domain
{
    public abstract class UserRole
    {
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }
    }
}