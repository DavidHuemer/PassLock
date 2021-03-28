using PassLock.Bitwarden.Data.Data.Objects.Items;
using PassLock.Bitwarden.Data.DTOs.Objects.Items;
using System;
using System.Linq;

namespace PassLock.Bitwarden.Converter.ObjectConverters
{
    /// <summary>
    /// Handles the converting of itemDTOs to real BitwardenItems
    /// </summary>
    public static class BitwardenItemDtoToItemConverter
    {
        /// <summary>
        /// Converts a BitwardenItemDTO to a real BitwardenItem
        /// </summary>
        /// <param name="dto">The BitwardenItemDTO that should be converted</param>
        /// <returns>The convertet dto</returns>
        public static BitwardenItem Convert(BitwardenItemDTO dto)
        {
            switch (dto.Type)
            {
                case 1:
                    //Login
                    return ConvertLoginItem(dto);
                case 2:
                    //Note
                    return ConvertNoteItem(dto);
                case 3:
                    //Card
                    return ConvertCardItem(dto);
                case 4:
                    //Identity
                    return ConvertIdentityItem(dto);
                default:
                    throw new ArgumentException("The type of the dto must be between 1-4");
            }
        }

        #region Convert Items

        /// <summary>
        /// Converts a BitwardenItemDTO to a LoginItem
        /// </summary>
        /// <param name="dto">The BitwardenItemDTO that should be convertet</param>
        /// <returns>The convertet LoginItem</returns>
        private static LoginItem ConvertLoginItem(BitwardenItemDTO dto)
        {
            var loginItem = new LoginItem();
            loginItem = (LoginItem)ConvertBasic(loginItem, dto);
            loginItem.Login = dto.Login.ConvertBack();
            return loginItem;
        }

        /// <summary>
        /// Converts a BitwardenItemDTO to a NoteItem
        /// </summary>
        /// <param name="dto">The BitwardenItemDTO that should be convertet</param>
        /// <returns>The convertet NoteItem</returns>
        private static NoteItem ConvertNoteItem(BitwardenItemDTO dto)
        {
            var noteItem = new NoteItem();
            noteItem = (NoteItem)ConvertBasic(noteItem, dto);
            return noteItem;
        }

        /// <summary>
        /// Converts a BitwardenItemDTO to a CardItem
        /// </summary>
        /// <param name="dto">The BitwardenItemDTO that should be convertet</param>
        /// <returns>The convertet CardItem</returns>
        private static CardItem ConvertCardItem(BitwardenItemDTO dto)
        {
            var cardItem = new CardItem();
            cardItem = (CardItem)ConvertBasic(cardItem, dto);
            cardItem.Card = dto.Card.ConvertBack();
            return cardItem;
        }

        /// <summary>
        /// Converts a BitwardenItemDTO to an IdentityItem
        /// </summary>
        /// <param name="dto">The BitwardenItemDTO that should be convertet</param>
        /// <returns>The convertet IdentityItem</returns>
        private static IdentityItem ConvertIdentityItem(BitwardenItemDTO dto)
        {
            var identityItem = new IdentityItem();
            identityItem = (IdentityItem)ConvertBasic(identityItem, dto);
            identityItem.Identity = dto.Identity.ConvertBack();
            return identityItem;
        }

        #endregion

        /// <summary>
        /// Converts the basic properties from the dto into the item
        /// </summary>
        /// <param name="item">The item in which the properties should be copied</param>
        /// <param name="dto">The source dto of the properties</param>
        /// <returns>The BitwardenItem with the properties of the dto</returns>
        private static BitwardenItem ConvertBasic(BitwardenItem item, BitwardenItemDTO dto)
        {
            item.Id = dto.Id;
            item.Name = dto.Name;
            item.Notes = dto.Notes;
            item.Favorite = dto.Favorite;

            if(dto.Fields != null)
            {
                item.Fields = dto.Fields
                    .Select(x => x.ConvertBack())
                    .ToList();
            }

            return item;
        }
    }
}
