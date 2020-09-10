using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    /// <summary>
    /// Represents Shuffle algorithm provider for shuffling a deck of cards
    /// </summary>
    public interface IShuffleProvider
    {
        string Name { get; }
        void Shuffle(IList<Card> cards);
    }
}
