using System;
using System.Linq;
using System.Security.Claims;

namespace MhLabs.AWSCognitoExtensions
{
    public static class ClaimsPrincipalExtension    
    {
        public static string UserId(this ClaimsPrincipal user) {            
            if (user == null || !user.Identity.IsAuthenticated) return null;            
            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "cognito:username") ?? user.Claims.FirstOrDefault(c => c.Type == "username");
            return userIdClaim?.Value;
        }        
    }
}
