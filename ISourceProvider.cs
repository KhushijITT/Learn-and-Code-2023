namespace CarbonFootprintCalculator;

public interface ISourceProvider
{
    string GetSource(string email);
}