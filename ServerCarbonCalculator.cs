namespace CarbonFootprintCalculator;

public class ServerCarbonCalculator : ICarbonCalculator
{
    private readonly string serverName;
    private readonly string dataCenterLocation;
    private readonly double usageHoursPerDay;
    private readonly double powerConsumptionWatt;
    private readonly double energyEfficiency;

    public ServerCarbonCalculator(string serverName, string dataCenterLocation, double usageHoursPerDay, double powerConsumptionWatt, double energyEfficiency)
    {
        this.serverName = serverName;
        this.dataCenterLocation = dataCenterLocation;
        this.usageHoursPerDay = usageHoursPerDay;
        this.powerConsumptionWatt = powerConsumptionWatt;
        this.energyEfficiency = energyEfficiency;
    }

    public CarbonFootprint CalculateCarbonFootprint()
    {
        double carbonIntensity = GetCarbonIntensity(dataCenterLocation);
        double energyConsumptionKWh = powerConsumptionWatt / 1000 * usageHoursPerDay;
        double dailyCarbonEmissions = energyConsumptionKWh * carbonIntensity;
        dailyCarbonEmissions /= energyEfficiency;

        return new CarbonFootprint
        {
            EntityType = "server",
            ServerName = serverName,
            DataCenterLocation = dataCenterLocation,
            DailyCarbonEmissions = dailyCarbonEmissions
        };
    }

    private double GetCarbonIntensity(string location)
    {
        switch (location.ToLower())
        {
            case "usa":
                return 0.3;
            default:
                return 0.3; 
        }
    }
}