namespace CarbonFootprintCalculator;

public class CarbonFootprint
{
    public string EntityType { get; set; }
    public string EmailId { get; set; }
    public string Source { get; set; }
    public double Inbox { get; set; }
    public double Sent { get; set; }
    public double Spam { get; set; }
    public double Total { get; set; }
    public string ServerName { get; set; }
    public string DataCenterLocation { get; set; }
    public double DailyCarbonEmissions { get; set; }
}