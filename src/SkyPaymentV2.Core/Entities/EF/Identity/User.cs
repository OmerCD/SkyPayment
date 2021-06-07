using Microsoft.AspNetCore.Identity;

namespace SkyPaymentV2.Core.Entities.EF.Identity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}