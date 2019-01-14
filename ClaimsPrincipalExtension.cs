using System;
using System.Linq;
using System.Security.Claims;

namespace MhLabs.AWSCognitoExtensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string UserId(this ClaimsPrincipal user)
        {
            if (user == null) return null;
            if (user.Claims != null && !user.Claims.Any() && !user.Identity.IsAuthenticated) return LocalFallback();
            if (!user.Identity.IsAuthenticated) return null;

            var claim = user.Claims.FirstOrDefault(c => c.Type == "cognito:username") ?? user.Claims.FirstOrDefault(c => c.Type == "username");
            return claim?.Value;
        }

        private static string LocalFallback()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                var userId = Environment.GetEnvironmentVariable("COGNITO_FALLBACK_USER_ID");
                return userId;
            }

            return null;
        }

        public static string Audience(this ClaimsPrincipal user)
        {
            if (user == null || !user.Identity.IsAuthenticated) return null;
            var claim = user.Claims.FirstOrDefault(c => c.Type == "aud") ?? user.Claims.FirstOrDefault(c => c.Type == "client_id");
            return claim?.Value;
        }

        public static string GetClaim(this ClaimsPrincipal user, string type)
        {
            if (user == null || !user.Identity.IsAuthenticated) return null;
            var claim = user.Claims.FirstOrDefault(c => c.Type == type);
            return claim?.Value;
        }
    }
}
