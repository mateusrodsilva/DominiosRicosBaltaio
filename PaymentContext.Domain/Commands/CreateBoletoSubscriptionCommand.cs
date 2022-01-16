using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public CreateBoletoSubscriptionCommand()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string PayerEmail { get; set; }
        
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }   
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(FirstName, 40, "FirstName", "Nome deve conter no m�ximo 40 caracteres")
                .IsLowerThan(LastName, 40, "LastName", "Sobrenome deve conter no m�ximo 40 caracteres")
                .IsEmail(Email, "Email", "Email inv�lido")
                /*.IsEmail(PayerEmail, "Payer Email", "Email do pagador inv�lido")
                .IsGreaterThan(Street, 80, "Address.Street", "A rua deve ter no m�ximo 80 caracteres")
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "0 total n�o pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valo pago � menos que o valor do pagamento")*/
            );
        }
    }
}