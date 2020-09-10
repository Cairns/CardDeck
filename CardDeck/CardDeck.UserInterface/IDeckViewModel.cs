using CardDeck.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CardDeck.UI
{
    public interface IDeckViewModel
    {
        ObservableCollection<IShuffleProvider> ShuffleProviders { get; set; }
        IShuffleProvider SelectedShuffleProvider { get; set; }
        Deck Deck { get; set; }
        ObservableCollection<Card> DrawnCards { get; set; }
        DelegateCommand ResetCommand { get; set; }
        DelegateCommand DrawCommand { get; set; }
        DelegateCommand ShuffleCommand { get; set; }
    }
}
