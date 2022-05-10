using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTests;

public class AddCurrencyExchangeServiceTests
{
    // sut
    private AddCurrencyExchangeService _service;

    // depencies
    private Mock<ICurrencyExchangeRepository> _mockCurrencyExchangeRepo;

    public AddCurrencyExchangeServiceTests()
    {
        _mockCurrencyExchangeRepo = new Mock<ICurrencyExchangeRepository>();
        _service = new AddCurrencyExchangeService(_mockCurrencyExchangeRepo.Object);
    }

    [Test]
    public void AddCurrencyWithNonExistingBaseCurrencyThrowsAnException()
    {
        // Arrange
        var command = new AddCurrencyExchangeCommand()
        {
            BaseCurrency =  "NON"
        };

        // Act & Assert
        Assert.Throws<CurrencyNotSupportedException>(() => _service.Execute(command));
    }

    [Test]
    public void AddCurrencyWithNonExistingTargetCurrencyThrowsAnException()
    {
        // Arrange
        var command = new AddCurrencyExchangeCommand()
        {
            BaseCurrency= "GBP",
            TargetCurrency = "NON"
        };

        // Act & Assert
        Assert.Throws<CurrencyNotSupportedException>(() => _service.Execute(command));
    }

    [TestCase(-1)]
    [TestCase(0)]
    public void AddCurrencyWithInvalidRateThrowsAnExption(int rate)
    {
        // Arrange
        var command = new AddCurrencyExchangeCommand()
        {
            BaseCurrency = "GBP",
            Rate = rate,
            TargetCurrency = "EUR"
        };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _service.Execute(command));
    }

    [Test]
    public void AddCurrencyInvokesCurrencyExchangeRepo()
    {
        // Arrange
        var command = new AddCurrencyExchangeCommand()
        {
            BaseCurrency = "GBP",
            Date = DateTime.Now,
            Rate = 3.5m,
            TargetCurrency = "EUR"
            
        };
        _mockCurrencyExchangeRepo.Setup(x => x.Add(It.IsAny<CurrencyRate>()));

        // Act
        _service.Execute(command);

        // Assert
        _mockCurrencyExchangeRepo.Verify(x => x.Add(It.IsAny<CurrencyRate>()), Times.Once);
    }
}