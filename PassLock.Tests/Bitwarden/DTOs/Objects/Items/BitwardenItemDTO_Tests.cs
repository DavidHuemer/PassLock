using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Tests.Helper.ItemHelpers;
using Xunit;

namespace PassLock.Tests.Bitwarden.DTOs.Objects.Items
{
    public class BitwardenItemDTO_Tests
    {
        [Fact]
        public void LoginItem_ConvertBackTest()
        {
            var dto = ItemDTOsHelper.CreateLoginItemDTO();
            var item = dto.ConvertBack();
            Assert.True(item is LoginItem);
            var loginItem = item as LoginItem;
            AssertGeneral(loginItem);
            Assert.Equal(ItemDTOsHelper.USERNAME, loginItem.Login.Username);
            Assert.Equal(ItemDTOsHelper.PASSWORD, loginItem.Login.Password);
            Assert.Single(loginItem.Login.Uris);
        }

        [Fact]
        public void NoteItem_ConvertBackTest()
        {
            var dto = ItemDTOsHelper.CreateNoteItemDTO();
            var item = dto.ConvertBack();
            Assert.True(item is NoteItem);
            var noteItem = item as NoteItem;
            AssertGeneral(noteItem);
        }

        [Fact]
        public void CardItem_ConvertBackTest()
        {
            var dto = ItemDTOsHelper.CreateCardItemDTO();
            var item = dto.ConvertBack();
            Assert.True(item is CardItem);
            var cardItem = item as CardItem;
            AssertGeneral(cardItem);
            Assert.Equal(ItemDTOsHelper.CARD_HOLDER_NAME, cardItem.Card.CardHolderName);
            Assert.Equal(ItemDTOsHelper.BRAND, cardItem.Card.Brand);
            Assert.Equal(ItemDTOsHelper.NUMBER, cardItem.Card.Number);
            Assert.Equal(ItemDTOsHelper.EXPIRED_MONTH, cardItem.Card.ExpiredMonth);
            Assert.Equal(ItemDTOsHelper.EXPIRED_YEAR, cardItem.Card.ExpiredYear);
            Assert.Equal(ItemDTOsHelper.CODE, cardItem.Card.Code);
        }

        [Fact]
        public void IdentityItem_ConvertBackTest()
        {
            var dto = ItemDTOsHelper.CreateIdentityItemDTO();
            var item = dto.ConvertBack();
            Assert.True(item is IdentityItem);
            var identityItem = item as IdentityItem;
            AssertGeneral(identityItem);
            Assert.Equal(ItemDTOsHelper.TITLE, identityItem.Identity.Title);
            Assert.Equal(ItemDTOsHelper.FIRSTNAME, identityItem.Identity.FirstName);
            Assert.Equal(ItemDTOsHelper.LASTNAME, identityItem.Identity.LastName);
            Assert.Equal(ItemDTOsHelper.ADDRESS, identityItem.Identity.Address1);
            Assert.Null(identityItem.Identity.Address2);
            Assert.Null(identityItem.Identity.Address3);
            Assert.Equal(ItemDTOsHelper.CITY, identityItem.Identity.City);
            Assert.Equal(ItemDTOsHelper.STATE, identityItem.Identity.State);
            Assert.Equal(ItemDTOsHelper.POSTALCODE, identityItem.Identity.PostalCode);
            Assert.Equal(ItemDTOsHelper.COUNTRY, identityItem.Identity.Country);
            Assert.Equal(ItemDTOsHelper.COMPANY, identityItem.Identity.Company);
            Assert.Equal(ItemDTOsHelper.EMAIL, identityItem.Identity.Email);
            Assert.Equal(ItemDTOsHelper.PHONE, identityItem.Identity.Phone);
            Assert.Equal(ItemDTOsHelper.SSN, identityItem.Identity.Ssn);
            Assert.Equal(ItemDTOsHelper.USERNAME, identityItem.Identity.Username);
            Assert.Equal(ItemDTOsHelper.PASSPORT_NUMBER, identityItem.Identity.PassportNumber);
            Assert.Equal(ItemDTOsHelper.LICENSE_NUMBER, identityItem.Identity.LicenseNumber);
        }

        private void AssertGeneral(BitwardenItem item)
        {
            Assert.Equal(ItemDTOsHelper.ID, item.Id);
            Assert.Equal(ItemDTOsHelper.NAME, item.Name);
            Assert.Equal(ItemDTOsHelper.FAVORITE, item.Favorite);
            Assert.Equal(ItemDTOsHelper.NOTES, item.Notes);
        }
    }
}
