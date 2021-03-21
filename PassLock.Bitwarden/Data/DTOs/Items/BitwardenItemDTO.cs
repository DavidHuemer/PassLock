using PassLock.Bitwarden.Data.Basics;
using PassLock.Bitwarden.Data.Data.Items;
using System.Collections.Generic;

namespace PassLock.Bitwarden.Data.DTOs.Items
{
    public class BitwardenItemDTO : BaseDTO<BitwardenItem>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Notes { get; set; }
        public bool Favorite { get; set; }
        public BitwardenItemLoginDTO Login { get; set; }

        public override BitwardenItem ConvertBack()
        {
            return new BitwardenItem
            {
                Id = Id,
                Name = Name,
                Notes = Notes,
                Favorite = Favorite,
                Login = Login.ConvertBack()
            };
        }
    }
}
