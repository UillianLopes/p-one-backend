namespace POne.Core.Auth
{
    public class IdentityServerProtectedApiConfig
    {
        public string IssuerUri { get; set; }
        public string Audience { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateIssuer { get; set; }
    }

}
