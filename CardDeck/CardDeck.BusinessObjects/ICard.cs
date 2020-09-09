using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeck
{
    public interface ICard
    {
        CardValue CardValue { get; }
        Suit Suit { get; }
    }
}
