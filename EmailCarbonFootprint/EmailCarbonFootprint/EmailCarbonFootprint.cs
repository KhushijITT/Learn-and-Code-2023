using Newtonsoft.Json.Linq;

class EmailCarbonFootprint
{
    static async Task Main(string[] args)
    {
        string apiUrl = "https://mocki.io/v1/a83536a6-1fce-459f-8bc9-15971b13cf23";

        Console.Write("Enter Email Address: ");
        string emailAddress = Console.ReadLine();

        Console.Write("Fetching data... ");

        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonResponse);

                    if (jsonObject["record"] is JArray emailRecords)
                    {
                        JObject matchedEmailObject = FindEmailAddressDetails(emailRecords, emailAddress);

                        if (matchedEmailObject != null)
                        {
                            Console.WriteLine("Success, data is fetched!");
                            CalculateAndPrintCarbonEmission(matchedEmailObject);
                        }
                        else
                        {
                            Console.WriteLine("Email address not found in the JSON data.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid JSON data structure. 'record' should be an array.");
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to load Email Details\nResponse code is: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static JObject FindEmailAddressDetails(JArray emailRecords, string emailId)
    {
        return emailRecords
            .OfType<JObject>()
            .FirstOrDefault(emailDetail => string.Equals((string)emailDetail["email"], 
            emailId, StringComparison.OrdinalIgnoreCase));
    }

    static void CalculateAndPrintCarbonEmission(JObject emailDetailObject)
    {
        Console.WriteLine($"{{\n" +
            $"source: {GetDomainFromEmail((string)emailDetailObject["email"])}\n" +
            $"inbox: {GetInboxMailsCarbonEmission((long)emailDetailObject["inbox"]):F2} KG\n" +
            $"sent: {GetSentMailCarbonEmission((long)emailDetailObject["sent"]):F2} KG\n" +
            $"spam: {GetSpamMailsCarbonEmission((long)emailDetailObject["spam"]):F2} KG\n" +
            $"}}");
    }

    static string GetDomainFromEmail(string emailId)
    {
        string[] parts = emailId.Split('@');
        return parts.Length > 1 ? parts[1].Split('.')[0] : null;
    }

    static double GetInboxMailsCarbonEmission(long inboxEmails)
    {
        return 0.25 * inboxEmails;
    }

    static double GetSentMailCarbonEmission(long sentEmails)
    {
        return 0.8 * sentEmails;
    }

    static double GetSpamMailsCarbonEmission(long spamEmails)
    {
        return 2 * spamEmails;
    }
}
