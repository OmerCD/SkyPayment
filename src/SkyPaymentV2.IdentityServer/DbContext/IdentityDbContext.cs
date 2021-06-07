using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyPaymentV2.Core.Entities.EF.Identity;

namespace SkyPaymentV2.IdentityServer.DbContext
{
    public class IdentityDbContext : IdentityDbContext<User, UserRole, int>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
            
        }
    }
}