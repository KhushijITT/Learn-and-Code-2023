using CarbonFootprintCalculator;

class CarbonFootprintEvaluator
{
    static void Main(string[] args)
    {
        bool exitRequested = false;

        while (!exitRequested)
        {
            Console.WriteLine("Carbon Footprint Calculator");
            Console.Write("Enter the entity type (email or server) or 'exit' to quit: ");
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
            {
                exitRequested = true;
            }
            else if (input == "email")
            {
                CalculateEmailCarbonFootprint();
            }
            else if (input == "server")
            {
                CalculateServerCarbonFootprint();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'email', 'server', or 'exit'.");
            }
        }
    }

    static void CalculateEmailCarbonFootprint()
    {
        Console.Write("Enter the email ID: ");
        string emailId = Console.ReadLine();

        Console.Write("Enter the number of spam emails received: ");
        if (!int.TryParse(Console.ReadLine(), out int spamEmails) || spamEmails < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number of spam emails.");
            return;
        }

        Console.Write("Enter the number of standard emails received: ");
        if (!int.TryParse(Console.ReadLine(), out int standardEmails) || standardEmails < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number of standard emails.");
            return;
        }

        Console.Write("Enter the number of emails with attachments received: ");
        if (!int.TryParse(Console.ReadLine(), out int attachmentEmails) || attachmentEmails < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid number of emails with attachments.");
            return;
        }

        ISourceProvider sourceProvider = new EmailSourceProvider();
        ICarbonCalculator emailCalculator = new EmailCarbonCalculator(emailId, sourceProvider, spamEmails, standardEmails, attachmentEmails);
        CarbonFootprint emailFootprint = emailCalculator.CalculateCarbonFootprint();
        PrintEmailCarbonFootprint(emailFootprint);
    }

    static void PrintEmailCarbonFootprint(CarbonFootprint footprint)
    {
        Console.WriteLine($"{footprint.EntityType} (entityType basis)");
        Console.WriteLine($"Email ID: {footprint.EmailId}");
        Console.WriteLine($"Source: {footprint.Source}");
        Console.WriteLine($"Inbox: {footprint.Inbox} KG");
        Console.WriteLine($"Sent: {footprint.Sent} KG");
        Console.WriteLine($"Spam: {footprint.Spam} KG");
        Console.WriteLine($"Total: {footprint.Total} KG");
    }

    static void CalculateServerCarbonFootprint()
    {
        Console.Write("Enter the server name: ");
        string serverName = Console.ReadLine();

        Console.Write("Enter the data center location (e.g.USA): ");
        string dataCenterLocation = Console.ReadLine();

        Console.Write("Enter the server's daily usage hours: ");
        if (!double.TryParse(Console.ReadLine(), out double usageHoursPerDay) || usageHoursPerDay <= 0)
        {
            Console.WriteLine("Invalid input for usage hours. Please enter a valid number.");
            return;
        }

        Console.Write("Enter the server's power consumption in watts: ");
        if (!double.TryParse(Console.ReadLine(), out double powerConsumptionWatt) || powerConsumptionWatt <= 0)
        {
            Console.WriteLine("Invalid input for power consumption. Please enter a valid number.");
            return;
        }

        Console.Write("Enter the server's energy efficiency (e.g.0.8 for 80% efficiency): ");
        if (!double.TryParse(Console.ReadLine(), out double energyEfficiency) || energyEfficiency <= 0 || energyEfficiency > 1)
        {
            Console.WriteLine("Invalid input for energy efficiency. Please enter a valid value between 0 and 1.");
            return;
        }

        ICarbonCalculator serverCalculator = new ServerCarbonCalculator(serverName, dataCenterLocation, usageHoursPerDay, powerConsumptionWatt, energyEfficiency);
        CarbonFootprint serverFootprint = serverCalculator.CalculateCarbonFootprint();
        PrintServerCarbonFootprint(serverFootprint);
    }

    static void PrintServerCarbonFootprint(CarbonFootprint footprint)
    {
        Console.WriteLine($"{footprint.EntityType} (entityType basis)");
        Console.WriteLine($"Server Name: {footprint.ServerName}");
        Console.WriteLine($"Data Center Location: {footprint.DataCenterLocation}");
        Console.WriteLine($"Daily Carbon Emissions: {footprint.DailyCarbonEmissions} KG");
    }
}