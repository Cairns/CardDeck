using CardDeck;
using CardDeck.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardDeckTests
{
    [TestClass]
    public class DeckUnitTests
    {
        [TestMethod]
        public void Creating_New_Deck_Should_Generate_Standard_52_Card_Deck()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            Assert.IsTrue(deck.Cards.Count == 52);
        }

        [TestMethod]
        public void Creating_New_Deck_Should_Generate_Full_Deck()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            Assert.IsTrue(deck.IsFull());
        }

        [TestMethod]
        public void Drawing_From_New_Deck_Should_Return_First_Card()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            var expected = deck.Cards[0];
            var actual = deck.Draw();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Shuffling_Deck_Should_Reorder_Deck()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            var expected = deck.Cards[0];

            deck.Shuffle();

            var actual = deck.Cards[0];

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void Shuffling_Non_Full_Deck_Should_Throw_Exception()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            deck.Draw();

            Assert.IsTrue(!deck.IsFull());
            Assert.ThrowsException<InvalidDeckOperationException>(() => deck.Shuffle());
        }

        [TestMethod]
        public void Shuffling_Empty_Deck_Should_Throw_Exception()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            deck.Cards.Clear();

            Assert.IsTrue(deck.IsEmpty());
            Assert.ThrowsException<InvalidDeckOperationException>(() => deck.Shuffle());
        }

        [TestMethod]
        public void Resetting_Deck_Should_Generate_New_Full_Deck()
        {
            var shuffler = new ReverseShuffleProvider();

            var deck = new Deck(shuffler);

            deck.Cards.Clear();

            deck.Reset();

            Assert.IsTrue(deck.IsFull());
        }
    }
}
