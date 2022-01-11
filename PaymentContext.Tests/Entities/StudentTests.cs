using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Mateus", "Rodrigues");
        _document = new Document("05952315003", EDocumentType.CPF);
        _address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "84555555");
        _email = new Email("m.rodriguessilva75@outlook.com");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
        
    }
    
    [TestMethod]
    public void ShoudReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne industries",_document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShoudReturnErrorWhenHadSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);
        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShoudReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne industries",_document, _address, _email);
        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }

    // [TestMethod]
    // public void ShoudReturnErrorWhenHadActiveSubscription()
    // {
        
    // }
}