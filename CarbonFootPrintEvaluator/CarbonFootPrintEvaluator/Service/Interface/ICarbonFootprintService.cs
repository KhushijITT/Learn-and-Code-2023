using CarbonFootPrintEvaluator.Model;

namespace CarbonFootPrintEvaluator.Service;

public interface ICarbonFootprintService
{
    EmailCarbonFootprint GetCarbonFootprintForEmail(EmailDataRequest emailDataRequest);
}
