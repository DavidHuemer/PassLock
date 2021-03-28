using Moq;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Tests.Basics;
using PassLock.Tests.Helper.Objects.Folders;
using Xunit;

namespace PassLock.Tests.Bitwarden.Data.Repositories
{
    public class BitwardenFoldersRepository_Tests : MoqTest
    {
        private Mock<IBitwardenObjectsService> mock;

        public BitwardenFoldersRepository_Tests()
        {
            mock = new Mock<IBitwardenObjectsService>();
        }

        #region LoadItems Count Test

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async void LoadItems_CountTest(int count)
        {
            var jsonStr = FolderDTOsHelper.CreateFolderDTOJsonList(count);
            mock.Reset();
            var t = CreateCommandResultTaskFromOutput(jsonStr);
            mock.Setup(service => service.LoadItems()).Returns(t);
            BitwardenFoldersRepository.Instance.Init(mock.Object);
            var items = await BitwardenFoldersRepository.Instance.LoadItems();
            Assert.Equal(count, items.Count);
        }

        #endregion

        #region UpdateItems Count Test

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public async void UpdateItems_CountTest(int count)
        {
            var jsonStr = FolderDTOsHelper.CreateFolderDTOJsonList(count);
            mock.Reset();
            var t = CreateCommandResultTaskFromOutput(jsonStr);
            mock.Setup(service => service.LoadItems()).Returns(t);
            BitwardenFoldersRepository.Instance.Init(mock.Object);
            await BitwardenFoldersRepository.Instance.UpdateItems();
            Assert.Equal(count, BitwardenFoldersRepository.Instance.Items.Count);
        }

        #endregion
    }
}
