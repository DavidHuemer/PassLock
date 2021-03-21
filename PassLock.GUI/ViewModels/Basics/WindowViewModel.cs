using System;
using System.ComponentModel;
using System.Windows;

namespace PassLock.GUI.ViewModels.Basics
{
    public abstract class WindowViewModel : BaseViewModel
    {
        public event EventHandler<EventArgs> Closing;
        public string Title { get; set; }

        public WindowViewModel()
        {

        }

        public void Close()
        {
            Closing?.Invoke(this, new EventArgs());
        }
    }
}
