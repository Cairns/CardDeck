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
        public string Name { get => "Reverse"; }
        public void Shuffle(IList<Card> cards)
        {
            var copy = new List<Card>(cards);
            cards.Clear();
            copy.Reverse();
            foreach (var item in copy)
            {
                cards.Add(item);
            }
        }
    }
}
