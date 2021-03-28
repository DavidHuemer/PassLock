using PassLock.Bitwarden.Data.DTOs.Objects.Items;
using PassLock.Tests.Basics;
using System.Collections.Generic;

namespace PassLock.Tests.Helper.ItemHelpers
{
    /// <summary>
    /// Helps creating item dtos
    /// </summary>
    public static class ItemDTOsHelper
    {
        #region Default Values

        public const string ID = "e55b521d-57a7-440a-b242-acf865da5ef8";
        public const string ORGANIZATION_ID = null;
        public const string NAME = "Example item";
        public const string FOLDER_ID = null;
        public const string TYPE = null;
        public const string NOTES = null;
        public const bool FAVORITE = true;
        public const List<BitwardenItemFieldDTO> FIELDS = null;
        public const List<string> COLLECTION_IDS = null;
        public const string REVISION_DATE = "2021-03-27T13:15:03.803Z";

        public const string USERNAME = "exampleUserName";
        public const string PASSWORD = "examplePassword";

        public const string TITLE = "Herr";
        public const string FIRSTNAME = "Max";
        public const string LASTNAME = "Mustermann";
        public const string CARD_HOLDER_NAME = FIRSTNAME + " " + LASTNAME;

        public const string BRAND = "Visa";
        public const string NUMBER = "123456789";
        public const string EXPIRED_MONTH = "04";
        public const string EXPIRED_YEAR = "2032";
        public const string CODE = "13579";

        public const string ADDRESS = "Musterstraße 22";
        public const string CITY = "MusterStadt";
        public const string STATE = "MusterState";
        public const string POSTALCODE = "1345";
        public const string COUNTRY = "MusterLand";
        public const string COMPANY = "MusterCompany";
        public const string EMAIL = BaseTest.Email;
        public const string PHONE = "1234 987654321";
        public const string SSN = "1234 25031980";
        public const string PASSPORT_NUMBER = "987654321";
        public const string LICENSE_NUMBER = "135792468";

        #endregion

        #region Login

        /// <summary>
        /// Creates a example LoginDTO
        /// </summary>
        /// <returns>Example of a LoginDTO</returns>
        public static BitwardenItemDTO CreateLoginItemDTO()
        {
            var loginDTO = CreateBaseDTO(1);
            loginDTO.Login = CreateLoginDTO();

            return loginDTO;
        }
        private static BitwardenItemLoginDTO CreateLoginDTO()
        {
            return new BitwardenItemLoginDTO
            {
                Username = USERNAME,
                Password = PASSWORD,
                Uris = new List<BitwardenUriDTO>
                    {
                        new BitwardenUriDTO {Url = "google.at"}
                    }
            };
        }

        #endregion

        #region Note

        /// <summary>
        /// Creates a example NoteDTO
        /// </summary>
        /// <returns>Example of a NoteDTO</returns>
        public static BitwardenItemDTO CreateNoteItemDTO(string notes = NOTES)
        {
            var noteItem = CreateBaseDTO(2);
            noteItem.SecureNote = new SecureNote { Type = 0 };
            return noteItem;
        }

        #endregion

        #region Card

        /// <summary>
        /// Creates a example CardDTO
        /// </summary>
        /// <returns>Example of a CardDTO</returns>
        public static BitwardenItemDTO CreateCardItemDTO()
        {
            var cardItem = CreateBaseDTO(3);
            cardItem.Card = CreateCardDTO();
            return cardItem;
        }
        private static BitwardenItemCardDTO CreateCardDTO()
        {
            return new BitwardenItemCardDTO
            {
                CardHolderName = CARD_HOLDER_NAME,
                Brand = BRAND,
                Number = NUMBER,
                ExpMonth = EXPIRED_MONTH,
                ExpYear = EXPIRED_YEAR,
                Code = CODE
            };
        }

        #endregion

        #region Identity

        /// <summary>
        /// Creates an example IdentityDTO
        /// </summary>
        /// <returns>Example of an IdentityDTO</returns>
        public static BitwardenItemDTO CreateIdentityItemDTO()
        {
            var identityItem = CreateBaseDTO(4);
            identityItem.Identity = CreateIdentityDTO();
            return identityItem;
        }

        private static BitwardenItemIdentityDTO CreateIdentityDTO()
        {
            return new BitwardenItemIdentityDTO
            {
                Title = TITLE,
                FirstName = FIRSTNAME,
                LastName = LASTNAME,
                Address1 = ADDRESS,
                City = CITY,
                State = STATE,
                PostalCode = POSTALCODE,
                Country = COUNTRY,
                Company = COMPANY,
                Email = EMAIL,
                Phone = PHONE,
                Ssn = SSN,
                Username = USERNAME,
                PassportNumber = PASSPORT_NUMBER,
                LicenseNumber = LICENSE_NUMBER
            };
        }

        #endregion

        /// <summary>
        /// Creates a basic ItemDTO
        /// </summary>
        /// <param name="type">The type (Login, Note...) of the item</param>
        /// <returns>Basic ItemDTO</returns>
        private static BitwardenItemDTO CreateBaseDTO(int type)
        {
            return new BitwardenItemDTO
            {
                Object = "Item",
                Id = ID,
                Name = NAME,
                OrganizationId = ORGANIZATION_ID,
                FolderId = FOLDER_ID,
                Type = type,
                Notes = NOTES,
                Favorite = FAVORITE,
                Fields = FIELDS,
                CollectionIds = COLLECTION_IDS,
                RevisionDate = REVISION_DATE
            };
        }
    }
}
