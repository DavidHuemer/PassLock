using PassLock.Bitwarden.Data.Data.Objects.Items;
using System.Collections.Generic;
using System.Linq;

namespace PassLock.GUI.Manager.Items
{
    public static class ItemsSearchManager
    {
        public static List<BitwardenItem> FilterItems(List<BitwardenItem> allItems, string searchText)
        {
            string realSearchText = searchText
                .Trim()
                .ToLower();

            return allItems
                .ToList()
                .Where(x => ShoulbItemBeAdded(x, realSearchText))
                .ToList();
        }


        private static bool ShoulbItemBeAdded(BitwardenItem item, string searchText)
        {
            if (searchText == "")
                return true;

            if (Contains(item.Name, searchText)) return true;
            if (Contains(item.Notes, searchText)) return true;

            return false;
        }

        private static bool Contains(string text, string searchText)
        {
            if (text == null || searchText == null) return false;

            var parts = text
                .ToLower()
                .Split(' ');
            foreach (var part in parts)
            {
                if (part.Contains(searchText))
                    return true;
            }

            return false;
        }
    }
}
