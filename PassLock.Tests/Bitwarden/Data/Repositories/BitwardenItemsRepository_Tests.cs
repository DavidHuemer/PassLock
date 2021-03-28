using Moq;
using PassLock.Bitwarden.Data.Data.Repositories;
using PassLock.Bitwarden.Services.Interfaces;
using PassLock.Tests.Basics;
using PassLock.Tests.Helper.ItemHelpers;
using Xunit;

namespace PassLock.Tests.Bitwarden.Data.Repositories
{
    public class BitwardenItemsRepository_Tests : MoqTest
    {
        private Mock<IBitwardenObjectsService> mock;

        public BitwardenItemsRepository_Tests()
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
            var jsonStr = ItemsJsonDTOsHelper.CreateItemsDTOJsonList(count);
            mock.Reset();
            var t = CreateCommandResultTaskFromOutput(jsonStr);
            mock.Setup(service => service.LoadItems()).Returns(t);
            BitwardenItemsRepository.Instance.Init(mock.Object);
            var items = await BitwardenItemsRepository.Instance.LoadItems();
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
            var jsonStr = ItemsJsonDTOsHelper.CreateItemsDTOJsonList(count);
            mock.Reset();
            var t = CreateCommandResultTaskFromOutput(jsonStr);
            mock.Setup(service => service.LoadItems()).Returns(t);
            BitwardenItemsRepository.Instance.Init(mock.Object);
            await BitwardenItemsRepository.Instance.UpdateItems(false);
            Assert.Equal(count, BitwardenItemsRepository.Instance.Items.Count);
        }

        #endregion
    }
}
