using PassLock.Bitwarden.Data.Data.Objects.Folders;

namespace PassLock.Bitwarden.Data.DTOs.Objects.Folders
{
    public class BitwardenFolderDTO : BitwardenObjectDTO<BitwardenFolder>
    {
        public override BitwardenFolder ConvertBack()
        {
            return new BitwardenFolder
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
