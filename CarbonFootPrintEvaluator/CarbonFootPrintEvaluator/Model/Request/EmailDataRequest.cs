namespace CarbonFootPrintEvaluator.Model;

public class EmailDataRequest
{
    public required string EmailId { get; set; }

    public int NumberOfStandardEmails { get; set; }

    public int NumberOfLongEmails { get; set; }

    public int NumberOfSpamEmails { get; set; }
}