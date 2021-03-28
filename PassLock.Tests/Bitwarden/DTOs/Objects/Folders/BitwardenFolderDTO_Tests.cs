using PassLock.Tests.Basics;
using PassLock.Tests.Helper.Objects.Folders;
using Xunit;

namespace PassLock.Tests.Bitwarden.DTOs.Objects.Folders
{
    public class BitwardenFolderDTO_Tests : BaseTest
    {
        [Fact]
        public void FolderDTO_Test()
        {
            var dto = FolderDTOsHelper.CreateFolderDTO();
            var folder = dto.ConvertBack();
            Assert.Equal(FolderDTOsHelper.ID, folder.Id);
            Assert.Equal(FolderDTOsHelper.NAME, folder.Name);
        }
    }
}
