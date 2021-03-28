using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Objects.Items.Options;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Items
{
    public class BitwardenItemFieldDTO : BaseDTO<BitwardenItemField>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public override BitwardenItemField ConvertBack()
        {
            return new BitwardenItemField
            {
                Name = Name,
                Value = Value,
                Type = Type
            };
        }
    }
}
