using Newtonsoft.Json;
using PassLock.Bitwarden.Data.Data.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace PassLock.Bitwarden.Handler.Items.Icons
{
    public class BitwardenIconsHandler
    {
        public static void StartItemsGetterThread(ObservableCollection<BitwardenItem> items)
        {
            System.Console.WriteLine("Star Getting icons");
            var t = new Thread(() => RealStart(items));
            t.Start();
        }

        private static void RealStart(ObservableCollection<BitwardenItem> items)
        {
            Thread.Sleep(5000);

            var itemsWithUrl = items
                .Where(x => x.Login.Uris != null && x.Login.Uris.Count > 0)
                .ToList();

            //The stored urls and their iccons
            var storedItems = GetStoredItems();

            foreach (var item in itemsWithUrl)
            {
                HandleItem(item, storedItems);
                //1. Check if there is already an icon for any url for this item
                //If there is already an icon return this icon(The path to it)
                //If there is no icon try all urls in this item to get an icon back
            }

            System.Console.WriteLine("Get icons finished");
        }

        private static void HandleItem(BitwardenItem item, Dictionary<string, string> storedItems)
        {
            
        }

        private string GetIcon()
        {
            return "";
        }

        private static Dictionary<string, string> GetStoredItems()
        {
            Dictionary<string, string> itemsDict = new Dictionary<string, string>();
            var itemsList = GetStoredItemsList();
            foreach (var item in itemsList)
            {
                itemsDict.Add(item.Url, item.IconName);
            }

            return itemsDict;
        }

        private static List<BitwardenUrlIcon> GetStoredItemsList()
        {
            try
            {
                string json = GetJSON();
                var items = JsonConvert.DeserializeObject<List<BitwardenUrlIcon>>(json);
                if (items == null)
                {
                    return new List<BitwardenUrlIcon>();
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<BitwardenUrlIcon>();
            }
        }

        private static string GetJSON()
        {
            return Properties.Settings.Default.ItemIcons;
        }

        private static void SaveJSON(string json)
        {
            Properties.Settings.Default.ItemIcons = json;
            Properties.Settings.Default.Save();
        }
    }
}
