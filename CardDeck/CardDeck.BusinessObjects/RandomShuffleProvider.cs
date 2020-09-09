using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    /// <summary>
    /// 
    /// </summary>
    public class RandomShuffleProvider : IShuffleProvider
    {
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
