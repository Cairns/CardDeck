using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    /// <summary>
    /// Shuffles a collection of cards using the Knuth-Fisher-Yates shuffle algorithm
    /// </summary>
    public class RandomShuffleProvider : IShuffleProvider
    {
        public string Name { get => "Knuth-Fisher-Yates"; }
        public void Shuffle(IList<Card> cards)
        {
            Random random = new Random();

            for (int i = cards.Count -1; i > 0; i--)
            {
                int swapPosition = random.Next(i + 1);
                Card card = cards[i];
                cards[i] = cards[swapPosition];
                cards[swapPosition] = card;
            }
        }
    }
}
