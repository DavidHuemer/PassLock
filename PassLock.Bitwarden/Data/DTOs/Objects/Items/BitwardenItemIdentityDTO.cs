using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenItemIdentityDTO : BaseDTO<BitwardenIdentity>
    {
        public string Title { get; set; } = null;
        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public string Address1 { get; set; } = null;
        public string Address2 { get; set; } = null;
        public string Address3 { get; set; } = null;
        public string City { get; set; } = null;
        public string State { get; set; } = null;
        public string PostalCode { get; set; } = null;
        public string Country { get; set; } = null;
        public string Company { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Ssn { get; set; } = null;
        public string Username { get; set; } = null;
        public string PassportNumber { get; set; } = null;
        public string LicenseNumber { get; set; } = null;

        public override BitwardenIdentity ConvertBack()
        {
            return new BitwardenIdentity
            {
                Title = Title,
                FirstName = FirstName,
                LastName = LastName,
                Address1 = Address1,
                Address2 = Address2,
                Address3 = Address3,
                City = City,
                State = State,
                PostalCode = PostalCode,
                Company = Company,
                Country = Country,
                Email = Email,
                Phone = Phone,
                Ssn = Ssn,
                PassportNumber = PassportNumber,
                Username = Username,
                LicenseNumber = LicenseNumber
            };
        }
    }
}
