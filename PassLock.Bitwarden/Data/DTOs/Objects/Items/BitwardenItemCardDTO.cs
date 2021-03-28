using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenItemCardDTO : BaseDTO<BitwardenCard>
    {
        public string CardHolderName { get; set; } = null;
        public string Brand { get; set; } = null;
        public string Number { get; set; } = null;
        public string ExpMonth { get; set; } = null;
        public string ExpYear { get; set; } = null;
        public string Code { get; set; } = null;

        public override BitwardenCard ConvertBack()
        {
            return new BitwardenCard
            {
                CardHolderName = CardHolderName,
                Brand = Brand,
                Number = Number,
                ExpiredMonth = ExpMonth,
                ExpiredYear = ExpYear,
                Code = Code
            };
        }
    }
}
