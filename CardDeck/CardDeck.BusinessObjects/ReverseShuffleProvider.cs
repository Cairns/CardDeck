using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CardDeck
{
    /// <summary>
    /// Reverses the current order of a collection of cards
    /// </summary>
    public class ReverseShuffleProvider : IShuffleProvider
    {
        public void Shuffle(IList<Card> cards)
        {
            Enumerable.Reverse(cards);
        }
    }
}
