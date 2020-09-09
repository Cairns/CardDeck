using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CardDeck.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IShuffleProvider shuffleProvider)
        {
            InitializeComponent();


            //Quickly demonstrate functionality
            Deck deck = new Deck(shuffleProvider);

            PrintDeck(deck);

            deck.Shuffle();

            PrintDeck(deck);

            Card card = deck.Draw();
            PrintCard(card);

            PrintDeck(deck);

            DrawDeck(deck);

            PrintDeck(deck);
        }

        private void PrintDeck(Deck deck)
        {
            foreach(Card card in deck.Cards)
            {
                System.Diagnostics.Debug.WriteLine(card.ToString());
            }
        }

        private void PrintCard(Card card)
        {
            System.Diagnostics.Debug.WriteLine(card.ToString());
        }

        private void DrawDeck(Deck deck)
        {
            while(true)
            {
                PrintCard(deck.Draw());
            }
        }
    }
}
