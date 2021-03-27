using System.ComponentModel;

namespace PassLock.Bitwarden.Data.Data.Items.Items
{
    public abstract class BitwardenItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
    }
}
