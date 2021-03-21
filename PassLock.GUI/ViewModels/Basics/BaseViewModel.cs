using System.ComponentModel;

namespace PassLock.GUI.ViewModels.Basics
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #pragma warning disable CS0067
        public event PropertyChangedEventHandler PropertyChanged;
        #pragma warning restore CS0067
    }
}
