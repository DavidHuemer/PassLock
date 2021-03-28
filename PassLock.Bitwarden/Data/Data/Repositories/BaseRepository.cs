using PassLock.Bitwarden.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PassLock.Bitwarden.Data.Data.Repositories
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
        public ObservableCollection<T> Items { get; protected set; } = new ObservableCollection<T>();

        protected IBitwardenObjectsService service;
        public void Init(IBitwardenObjectsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Updates the items
        /// </summary>
        public virtual async Task UpdateItems()
        {
            Console.WriteLine($"BaseRepository update items");
            Items.Clear();
            var items = await LoadItems();
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
        public abstract Task<List<T>> LoadItems();
    }
}
