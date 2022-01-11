using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class DocumentTests
{
    // Para aprimorar os testes - Red, Green, Refactor

    //CNPJ
    [TestMethod]
    public void ShoudReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }
    
    [TestMethod]
    public void ShoudReturnSuccessWhenCNPJIsValid()
    {
        var doc = new Document("56541850000151", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }
    
    //CPF
    [TestMethod]
    public void ShoudReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }
    
    // Testando muitos documentos
    [TestMethod]
    [DataTestMethod]
    [DataRow("45167280010")]
    [DataRow("99978931074")]
    [DataRow("46362810040")]
    public void ShoudReturnSuccessWhenCPFIsValid(string cpf)
    {
        var doc = new Document(cpf, EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}