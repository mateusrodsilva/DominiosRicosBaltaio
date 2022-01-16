using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    // Para aprimorar os testes - Red, Green, Refactor

    //Document
    [TestMethod]
    public void ShoudReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Bruce";
        command.LastName = "Wayne";
        command.Document = "99999999999";
        command.Email = "hello@balta.902";
        command.BarCode = "123456789";
        command.BoletoNumber = "12345678987";
        command.PaymentNumber = "12321";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 60;
        command.TotalPaid   = 60; 
        command.Payer = "WAYNE CORP";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "batman@dc.com";
        command.Street = "asdas";
        command.Number = "asdas";
        command.Neighborhood = "asdasd";
        command.City = "as";
        command.State = "as";
        command.Country = "as";
        command.ZipCode = "12345678";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}