using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    public interface IDeck
    {
        public IList<Card> Cards { get; }

        void SetShuffleProvider(IShuffleProvider shuffleProvider);

        void Reset();
        Card Draw();
        void Shuffle();
        bool IsEmpty();
        bool IsFull();
    }
}
