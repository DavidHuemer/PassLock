using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PassLock.Bitwarden.Data.Data.Items.Repositories
{
    /// <summary>
    /// Base repository for all repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The stored items
        /// </summary>
        public static ObservableCollection<T> Items { get; protected set; } = new ObservableCollection<T>();

        /// <summary>
        /// Updates the items
        /// </summary>
        public virtual void UpdateItems()
        {
            Console.WriteLine($"BaseRepository update items");
            Items.Clear();
            var items = LoadItems();
            foreach (var item in items)
            {
                Items.Add(item);
            }
            Console.WriteLine($"BaseRepository updated items");
        }

        /// <summary>
        /// Loads the items from the source
        /// </summary>
        /// <returns>The loaded items</returns>
        protected abstract List<T> LoadItems();
    }
}
