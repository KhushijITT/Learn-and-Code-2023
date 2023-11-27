namespace EmailCarbonFootPrint;

public class EmailCarbonFootprint
{
    public double Inbox { get; set; }
    public double Spam { get; set; }
    public double Sent { get; set; }
    public double Total { get; set; }

    public static EmailCarbonFootprint CalculateCarbonFootprint(int inboxCount, int spamCount, int sentCount)
    {
        double inboxFootprint = spamCount * Coefficients.Spam + inboxCount * Coefficients.Inbox;
        double sentFootprint = sentCount * Coefficients.Sent;
        double spamFootprint = spamCount * Coefficients.Spam;

        double totalFootprint = (inboxFootprint + sentFootprint) / Coefficients.ScalingFactor;

        return new EmailCarbonFootprint
        {
            Inbox = inboxFootprint / Coefficients.ScalingFactor,
            Spam = spamFootprint / Coefficients.ScalingFactor,
            Sent = sentFootprint / Coefficients.ScalingFactor,
            Total = totalFootprint
        };
    }
}