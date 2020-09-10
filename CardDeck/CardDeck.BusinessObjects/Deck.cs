using CardDeck.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CardDeck
{
    /// <summary>
    /// Represents a deck of cards
    /// </summary>
    public class Deck : IDeck
    {
        protected IShuffleProvider shuffler;

        protected IList<Card> _cards;
        public IList<Card> Cards
        {
            get
            {
                if (this._cards == null) { this._cards = new ObservableCollection<Card>(); }
                return this._cards;
            }
            private set
            {
                this._cards = value;
            }
        }

        public Deck(IShuffleProvider shuffleProvider)
        {
            this.SetShuffleProvider(shuffleProvider);
            this.Reset();
        }

        /// <summary>
        /// Discards the first available card from the deck
        /// </summary>
        /// <returns></returns>
        public Card Draw()
        {
            if (this.IsEmpty())
            {
                throw new InvalidDeckOperationException("Cannot draw from an empty deck");
            }

            Card card = this.Cards.FirstOrDefault();
            this.Cards.Remove(card);

            return card;
        }

        public bool IsEmpty()
        {
            return this.Cards != null && !this.Cards.Any();
        }

        public bool IsFull()
        {
            return this.Cards != null && this.Cards.Count() == 52;
        }

        /// <summary>
        /// Resets this Deck to the initial 52 card deck
        /// </summary>
        public void Reset()
        {
            //Ensure card collection is empty
            this.Cards.Clear();

            //Construct the base deck of 52 cards, consisting of each suit and card value combination
            for (int suitIndex = 0; suitIndex < 4; suitIndex++)
            {
                for (int cardValueIndex = 0; cardValueIndex < 13; cardValueIndex++)
                {
                    this.Cards.Add(new Card((CardValue)cardValueIndex, (Suit)suitIndex));
                }
            }
        }

        /// <summary>
        /// Specify the ShuffleProvider for shuffling this deck of cards
        /// </summary>
        /// <param name="shuffleProvider"></param>
        public void SetShuffleProvider(IShuffleProvider shuffleProvider)
        {
            this.shuffler = shuffleProvider;
        }

        /// <summary>
        /// Shuffles this deck of cards using the shuffle provider assigned to this deck
        /// </summary>
        public void Shuffle()
        {
            if (this.IsEmpty())
            {
                throw new InvalidDeckOperationException("Cannot shuffle empty deck");
            }

            if (!this.IsFull())
            {
                throw new InvalidDeckOperationException("Cannot shuffle partial deck, must be full");
            }

            this.shuffler.Shuffle(this.Cards);
        }
    }
}
