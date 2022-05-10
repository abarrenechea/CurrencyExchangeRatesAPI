using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Services;
using Moq;
using NUnit.Framework;
using System;

namespace UnitTests;

public class UpdateCurrencyExchangeServiceTests
{
    // sut
    private UpdateCurrencyExchangeService _service;

    // dependencies
    private Mock<ICurrencyExchangeRepository> _mockCurrencyExchangeRepo;

    public UpdateCurrencyExchangeServiceTests()
    {
        _mockCurrencyExchangeRepo = new Mock<ICurrencyExchangeRepository>();
        _service = new UpdateCurrencyExchangeService(_mockCurrencyExchangeRepo.Object);
    }

    [TestCase(-1)]
    [TestCase(0)]
    public void UpdateCurrencyWithRateOutOfRangeThrowsAnException(decimal rate)
    {
        // Arrange
        var command = new UpdateCurrencyExchangeCommand()
        {
            Id = Guid.NewGuid().ToString(),
            Rate = rate
        };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _service.Execute(command));
    }

    [Test]
    public void UpdateCurrencyWithNonExistingIdThrowsAnException()
    {
        // Arrange
        var command = new UpdateCurrencyExchangeCommand()
        {
            Id = Guid.NewGuid().ToString(),
            Rate = 3.15m
        };

        // Act & Assert
        Assert.Throws<CurrencyExchangeNotFoundException>(() => _service.Execute(command));
    }

    [Test]
    public void UpdateCurrencyInvokesCurrencyExchangeRepo()
    {
        // Arrange
        CurrencyRate currencyRateToUpdate = new CurrencyRate()
        {
            Rate = 3.1m,
            Id = Guid.NewGuid().ToString()
        };

        _mockCurrencyExchangeRepo
            .Setup(x => x.GetById(It.Is<string>(s => s == currencyRateToUpdate.Id)))
            .Returns(currencyRateToUpdate);

        var command = new UpdateCurrencyExchangeCommand()
        {
            Id = currencyRateToUpdate.Id,
            Rate = 3.25m
        };

        // Act
        _service.Execute(command);

        // Assert
        _mockCurrencyExchangeRepo
            .Verify(x => x.Update(It.Is<CurrencyRate>(c => c.Id == currencyRateToUpdate.Id)), Times.Once);
    }
}