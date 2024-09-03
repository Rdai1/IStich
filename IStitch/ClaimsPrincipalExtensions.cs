using System.Security.Claims;
namespace IStitch
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserid(this ClaimsPrincipal user) 
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
