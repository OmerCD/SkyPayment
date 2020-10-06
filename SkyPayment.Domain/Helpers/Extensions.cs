using System.Security.Claims;

namespace SkyPayment.Domain.Helpers
{
    public static class Extensions
    {
        public static string GetManagementUserId(this ClaimsPrincipal user)
        {
            return (user.Identity as ClaimsIdentity)?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}