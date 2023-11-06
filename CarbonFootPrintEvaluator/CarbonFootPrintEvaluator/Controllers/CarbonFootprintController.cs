using CarbonFootPrintEvaluator.Model;
using CarbonFootPrintEvaluator.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarbonFootPrintEvaluator.Controllers;

[Route("[controller]")]
[ApiController]
public class CarbonFootprintController : ControllerBase
{
    private readonly ILogger<CarbonFootprintController> _logger;
    private readonly ICarbonFootprintService _carbonFootprintService;

    public CarbonFootprintController(ILogger<CarbonFootprintController> logger, ICarbonFootprintService carbonFootPrintService)
    {
        _logger = logger;
        _carbonFootprintService = carbonFootPrintService;
    }

    [HttpPost]
    public ActionResult<EmailCarbonFootprint> GetCarbonFootprintForEmail(EmailDataRequest emailDataRequest)
    {
        try
        {
            return Ok(_carbonFootprintService.GetCarbonFootprintForEmail(emailDataRequest));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Problem(statusCode: (int)HttpStatusCode.BadRequest, title: ex.Message, type: ((int)HttpStatusCode.BadRequest).ToString());
        }
    }
}