using System.Collections.Generic;

namespace GetItDone.Domain
{
    public abstract class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}