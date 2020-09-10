using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck.Common
{
    public interface IBindableBase : INotifyPropertyChanged, IChangeTracking
    {
        bool SetProperty<T>(ref T storage, T value, string propertyName);
    }
}
