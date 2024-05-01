using Microsoft.AspNetCore.Identity;
namespace SportsStore.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int customerId;
    }
}
