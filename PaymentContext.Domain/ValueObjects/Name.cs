using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsLowerThan(FirstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres")
                .IsLowerThan(LastName, 40, "Name.LastName", "Sobrenome deve conter no máximo 40 caracteres")

            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}