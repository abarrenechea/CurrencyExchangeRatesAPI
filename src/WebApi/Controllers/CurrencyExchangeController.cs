using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyExchangeController : ControllerBase
{
    private readonly ILogger<CurrencyExchangeController> _logger;
    private readonly ICommandService<AddCurrencyExchangeCommand> _createCurrencyExchangeService;
    private readonly ICommandService<UpdateCurrencyExchangeCommand> _updateCurrencyRateservice;
    private readonly IQueryService<string, CurrencyRate> _currencyExchangeQueryService;

    public CurrencyExchangeController(
        ILogger<CurrencyExchangeController> logger,
        ICommandService<AddCurrencyExchangeCommand> currencyExchangeService,
        ICommandService<UpdateCurrencyExchangeCommand> updateCurrencyExchangeService,
        IQueryService<string, CurrencyRate> currencyExchangeQueryService)
        
    {
        _logger = logger;
        _createCurrencyExchangeService = currencyExchangeService;
        _updateCurrencyRateservice = updateCurrencyExchangeService;
        _currencyExchangeQueryService = currencyExchangeQueryService;
    }

    /// <summary>
    /// Get the list of currency exchange rates for the given currency.
    /// </summary>
    /// <param name="currency">Currency code (ISO 4217)</param>
    /// <returns></returns>
    [HttpGet(Name = "GetCurrencyExchange/{currency}")]
    public IEnumerable<CurrencyRate> Get(string currency)
    {
        return _currencyExchangeQueryService.Run(currency);
    }

    /// <summary>
    /// Adds a new currency exchange rate.
    /// </summary>
    /// <param name="model"></param>
    [HttpPost(Name = "PostCurrencyExchange")]
    public void Post(AddCurrencyExchangeCommand model)
    {
        _createCurrencyExchangeService.Execute(model);
    }

    /// <summary>
    /// Updates the exchange rate of an existing item.
    /// </summary>
    /// <param name="model"></param>
    [HttpPut(Name = "PutCurrencyExchange")]
    public void Put(UpdateCurrencyExchangeCommand model)
    {
        _updateCurrencyRateservice.Execute(model);
    }
}
