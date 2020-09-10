using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck.UI.Common
{
    public interface IViewModelBase
    {
        IViewBase View { get; }

        void DisplayError(string message);

        void DisplayError(System.Exception ex);
    }
}
