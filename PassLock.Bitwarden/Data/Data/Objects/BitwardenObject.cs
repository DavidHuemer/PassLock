using System.ComponentModel;

namespace PassLock.Bitwarden.Data.Data.Objects
{
    /// <summary>
    /// Base class for all BitwardenObjects
    /// </summary>
    public abstract class BitwardenObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
