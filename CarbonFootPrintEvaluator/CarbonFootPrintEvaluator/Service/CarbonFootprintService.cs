using CarbonFootPrintEvaluator.Common;
using CarbonFootPrintEvaluator.Model;

namespace CarbonFootPrintEvaluator.Service;

public class CarbonFootprintService : ICarbonFootprintService
{

    public EmailCarbonFootprint GetCarbonFootprintForEmail(EmailDataRequest emailDataRequest)
    {

        var CarbonFootPrintByStandardEmails = emailDataRequest.NumberOfStandardEmails * Constants.CarbonEmissionForStandardEmail;
        var CarbonFootPrintByLongEmails = emailDataRequest.NumberOfLongEmails * Constants.CarbonEmissionForLongEmail;
        var CarbonFootPrintBySpamEmails = emailDataRequest.NumberOfSpamEmails * Constants.CarbonEmissionForSpamEmail;

        return new EmailCarbonFootprint(CarbonFootPrintByLongEmails, CarbonFootPrintByStandardEmails, CarbonFootPrintBySpamEmails)
        {
            EmailId = emailDataRequest.EmailId,
        };
    }
}