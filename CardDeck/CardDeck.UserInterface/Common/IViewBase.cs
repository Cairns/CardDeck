using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck.UI.Common
{
    public interface IViewBase
    {
        void DisplayError(string message);

        void DisplayError(System.Exception ex);
    }
}
