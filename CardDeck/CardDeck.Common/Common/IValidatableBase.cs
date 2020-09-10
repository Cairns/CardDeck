using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck.Common
{
    public interface IValidatableBase : INotifyDataErrorInfo, IValidatableObject
    {
        bool SetProperty<T>(ref T storage, T value, string propertyName);
        void ValidateProperty<T>(T value, string propertyName);
        void Validate();

        System.Collections.Generic.IEnumerable<string> GetErrors();
        Dictionary<string, List<string>> Errors { get; }
        string ErrorMessage { get; }
    }
}
