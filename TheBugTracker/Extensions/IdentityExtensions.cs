using System.Security.Claims;
using System.Security.Principal;

namespace TheBugTracker.Extensions
{
    public static class IdentityExtensions
    {
        public static int? GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId");
            // Parse CompanyId claim to integer
            return (claim != null) ? int.Parse(claim.Value) : null;
        }
    }
}
