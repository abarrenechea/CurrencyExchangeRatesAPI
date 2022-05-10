using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task GetRequestWithUnkownCurrencyReturns404()
    {
        // Arrange
        var api = new WebApiApplicationFactory();

        // Act
        var response = await api.CreateClient().GetAsync("/CurrencyExchange?currency=PEL");

        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Test]
    public async Task GetRequestWithSupportedCurrencyReturns200()
    {
        // Arrange
        var api = new WebApiApplicationFactory();

        // Act
        var response = await api.CreateClient().GetAsync($"/CurrencyExchange?currency={Currencies.GBP}");
        var content = await response.Content.ReadAsStringAsync();
        var items = JsonSerializer.Deserialize<List<CurrencyRate>>(content);

        // Assert
        Assert.IsTrue(response.IsSuccessStatusCode);
        Assert.IsNotNull(items);
        Assert.AreEqual(7, items.Count);
    }

    [TestCase("INVALID_CURRENCY", "USD", 3.1)]
    [TestCase("USD", "INVALID_CURRENCY", 3.1)]
    [TestCase("USD", "EUR", -1)]
    public async Task AddRequestWithSupportedCurrencyReturns400(string baseCurrency, string targetCurrency, decimal rate)
    {
        // Arrange
        var api = new WebApiApplicationFactory();
        var table = new AddCurrencyExchangeCommand()
        {
            BaseCurrency = baseCurrency,
            Date = DateTime.Now,
            Rate = rate,
            TargetCurrency = targetCurrency
        };

        string json = JsonSerializer.Serialize(table);

        StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        // Act
        var response = await api.CreateClient().PostAsync("/CurrencyExchange", httpContent);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }
}