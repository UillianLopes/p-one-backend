namespace POne.Identity.Domain.Settings
{
    public record GeneralSettings
    {
        public string Language { get; set; }
        public string Currency { get; set; }
        public FinancialSettings Financial { get; set; }
    }
}

