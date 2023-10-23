namespace CarbonFootprintCalculator;

public class EmailSourceProvider : ISourceProvider
{
    public string GetSource(string email)
    {
        if (email.Contains("@gmail.com"))
            return "Gmail";
        else if (email.Contains("@outlook.com"))
            return "Outlook";
        else if (email.Contains("@yahoo.com"))
            return "Yahoo";
        else
            return "Unknown";
    }
}