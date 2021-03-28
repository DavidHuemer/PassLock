using PassLock.Bitwarden.Converter.ObjectConverters;
using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.DTOs.Objects.Items;
using PassLock.Tests.Basics;
using PassLock.Tests.Helper.ItemHelpers;
using System.Collections.Generic;
using Xunit;

namespace PassLock.Tests.Bitwarden.Converter.ObjectConverters
{
    public class BitwardenItemDtoToItemConverter_Tests : BaseTest
    {
        private const string FIELD_NAME = "Example name";
        private const string FIELD_VALUE = "Example value";
        private const string FIELD_TYPE = "0";

        #region Items Tests
        
        [Fact]
        public void LoginItem_Test()
        {
            var dto = ItemDTOsHelper.CreateLoginItemDTO();
            var item = BitwardenItemDtoToItemConverter.Convert(dto);
            Assert.True(item is LoginItem);
            var loginItem = item as LoginItem;
            AssertGeneral(loginItem);
            Assert.Equal(ItemDTOsHelper.USERNAME, loginItem.Login.Username);
            Assert.Equal(ItemDTOsHelper.PASSWORD, loginItem.Login.Password);
            Assert.Single(loginItem.Login.Uris);
        }

        [Fact]
        public void NoteItem_Test()
        {
            var dto = ItemDTOsHelper.CreateNoteItemDTO();
            var item = BitwardenItemDtoToItemConverter.Convert(dto);
            Assert.True(item is NoteItem);
            var noteItem = item as NoteItem;
            AssertGeneral(noteItem);
        }

        [Fact]
        public void CardItem_Test()
        {
            var dto = ItemDTOsHelper.CreateCardItemDTO();
            var item = BitwardenItemDtoToItemConverter.Convert(dto);
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
        public void IdentityItem_Test()
        {
            var dto = ItemDTOsHelper.CreateIdentityItemDTO();
            var item = BitwardenItemDtoToItemConverter.Convert(dto);
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

        #endregion

        [Fact]
        public void Fields_Test()
        {
            var dto = ItemDTOsHelper.CreateNoteItemDTO();
            dto.Fields = new List<BitwardenItemFieldDTO>
            {
                new BitwardenItemFieldDTO
                {
                    Name = FIELD_NAME,
                    Value = FIELD_VALUE,
                    Type = FIELD_TYPE
                }
            };

            var noteItem = (NoteItem)BitwardenItemDtoToItemConverter.Convert(dto);
            Assert.Single(noteItem.Fields);
            Assert.Equal(FIELD_NAME, noteItem.Fields[0].Name);
            Assert.Equal(FIELD_VALUE, noteItem.Fields[0].Value);
            Assert.Equal(FIELD_TYPE, noteItem.Fields[0].Type);
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
