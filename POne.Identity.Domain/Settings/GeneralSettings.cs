namespace POne.Identity.Domain.Settings
{
    public abstract record GeneralSettings
    {
        public string Language { get; set; }
        public FinancialSettings Financial { get; set; }
    }
}

