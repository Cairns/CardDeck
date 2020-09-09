using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    public class Card : ICard, IComparable<Card>
    {
        public CardValue CardValue { get; private set; }
        public Suit Suit { get; private set; }

        public Card(CardValue value, Suit suit)
        {
            this.CardValue = value;
            this.Suit = suit;
        }

        public int CompareTo(Card other)
        {
            //Compare card values, as suits are intrinsically the same value
            if (this.CardValue != other.CardValue)
            {
                return this.CardValue.CompareTo(other.CardValue);
            }

            //Use suits as a fallback for distinguishing cards as being different
            return this.Suit.CompareTo(other.Suit);
        }

        public override string ToString()
        {
            return $"{this.CardValue} : {this.Suit}";
        }
    }
}
