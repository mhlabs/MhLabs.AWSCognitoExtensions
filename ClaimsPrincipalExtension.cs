using System;
using System.Linq;
using System.Security.Claims;

namespace MhLabs.AWSCognitoExtensions
{
    public static class ClaimsPrincipalExtension    
    {
        public static string UserId(this ClaimsPrincipal user) {            
            if (user == null || !user.Identity.IsAuthenticated) return null;            
            var claim = user.Claims.FirstOrDefault(c => c.Type == "cognito:username") ?? user.Claims.FirstOrDefault(c => c.Type == "username");
            return claim?.Value;
        }        

        public static string Audience(this ClaimsPrincipal user) {            
            if (user == null || !user.Identity.IsAuthenticated) return null;            
            var claim = user.Claims.FirstOrDefault(c => c.Type == "aud") ?? user.Claims.FirstOrDefault(c => c.Type == "ClientId");
            return claim?.Value;
        }        
        
        public static string GetClaim(this ClaimsPrincipal user, string type) {            
            if (user == null || !user.Identity.IsAuthenticated) return null;            
            var claim = user.Claims.FirstOrDefault(c => c.Type == type);
            return claim?.Value;
        }        
    }
}
