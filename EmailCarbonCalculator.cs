namespace CarbonFootprintCalculator
{
    public class EmailCarbonCalculator : ICarbonCalculator
    {
        private readonly string emailId;
        private readonly ISourceProvider sourceProvider;
        private readonly int spamEmails;
        private readonly int standardEmails;
        private readonly int attachmentEmails;

        public EmailCarbonCalculator(string emailId, ISourceProvider sourceProvider, int spamEmails, int standardEmails, int attachmentEmails)
        {
            this.emailId = emailId;
            this.sourceProvider = sourceProvider;
            this.spamEmails = spamEmails;
            this.standardEmails = standardEmails;
            this.attachmentEmails = attachmentEmails;
        }

        public CarbonFootprint CalculateCarbonFootprint()
        {
            double inboxFootprint = spamEmails * 0.03 + standardEmails * 4 + attachmentEmails * 50;
            double sentFootprint = standardEmails * 4;
            double spamFootprint = spamEmails * 0.03;

            string source = sourceProvider.GetSource(emailId);

            double sourceFactor = CalculateSourceFactor(source);

            inboxFootprint *= sourceFactor;
            sentFootprint *= sourceFactor;
            spamFootprint *= sourceFactor;

            double totalFootprint = (inboxFootprint + sentFootprint) / 1000;

            return new CarbonFootprint
            {
                EntityType = "email",
                EmailId = emailId,
                Source = source,
                Inbox = inboxFootprint / 1000,
                Sent = sentFootprint / 1000,
                Spam = spamFootprint / 1000,
                Total = totalFootprint
            };
        }

        private double CalculateSourceFactor(string source)
        {
            switch (source)
            {
                case "Gmail":
                    return 0.9;
                case "Outlook":
                    return 1.1;
                case "Yahoo":
                    return 1.2;
                default:
                    return 1.0; 
            }
        }
    }
}