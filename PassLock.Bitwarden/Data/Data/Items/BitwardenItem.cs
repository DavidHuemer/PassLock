using System;
using System.ComponentModel;

namespace PassLock.Bitwarden.Data.Data.Items
{
    public class BitwardenItem : INotifyPropertyChanged
    {
#pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0067

        public string Id { get; set; }
        public string Name { get; set; }
        public string IconSource { get; set; } = null;
        public string Notes { get; set; }
        public bool Favorite { get; set; }
        public BitwardenItemLogin Login { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
