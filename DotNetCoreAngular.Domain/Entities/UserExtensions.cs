using System.Collections.Generic;

namespace DotNetCoreAngular.Domain.Entities
{
    public class UserExtensions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Theme { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
