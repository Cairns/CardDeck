using CardDeck.Common;
using CardDeck.Exceptions;
using CardDeck.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CardDeck.UI
{
    public class DeckViewModel : BindableBase, IBindableBase, IViewModelBase, IDeckViewModel
    {
        public IViewBase View { get; protected set; }

        private ObservableCollection<IShuffleProvider> _shuffleProviders;
        public ObservableCollection<IShuffleProvider> ShuffleProviders
        {
            get
            {
                if (_shuffleProviders == null)
                {
                    _shuffleProviders = new ObservableCollection<IShuffleProvider>();
                }
                return _shuffleProviders;
            }
            set
            {
                SetProperty(ref _shuffleProviders, value);
                ShuffleCommand.OnExecuteChanged();
            }
        }

        private IShuffleProvider _selectedShuffleProvider;
        public IShuffleProvider SelectedShuffleProvider
        {
            get => _selectedShuffleProvider;
            set
            {
                SetProperty(ref _selectedShuffleProvider, value);
                Deck.SetShuffleProvider(value);
                ShuffleCommand.OnExecuteChanged();
            }
        }

        private Deck _deck;
        public Deck Deck
        {
            get
            {
                if (_deck == null)
                {
                    _deck = new Deck(SelectedShuffleProvider);
                }
                return _deck;
            }
            set
            {
                SetProperty(ref _deck, value);
                ResetCommand.OnExecuteChanged();
                DrawCommand.OnExecuteChanged();
                ShuffleCommand.OnExecuteChanged();
            }
        }

        private ObservableCollection<Card> _drawnCards;
        public ObservableCollection<Card> DrawnCards
        {
            get
            {
                if (_drawnCards == null)
                {
                    _drawnCards = new ObservableCollection<Card>();
                }
                return _drawnCards;
            }
            set
            {
                SetProperty(ref _drawnCards, value);
            }
        }

        public DelegateCommand ResetCommand { get; set; }
        public DelegateCommand DrawCommand { get; set; }
        public DelegateCommand ShuffleCommand { get; set; }

        public DeckViewModel()
            :base()
        {
        }

        public DeckViewModel(IViewBase view)
            :base()
        {
            this.View = view;

            ResetCommand = new DelegateCommand(OnReset);
            //Commented out, so DrawCommand can demonstrate error handling when the deck is empty and we attempt to draw from it.
            //DrawCommand = new DelegateCommand(OnDraw, CanDraw); //We would really use this so we cannot draw from an empty deck
            DrawCommand = new DelegateCommand(OnDraw);
            ShuffleCommand = new DelegateCommand(OnShuffle, CanShuffle);

            ShuffleProviders.Add(new ReverseShuffleProvider());
            ShuffleProviders.Add(new RandomShuffleProvider());
        }

        private void Reset()
        {
            this.Deck.Reset();
            this.DrawnCards.Clear();
        }
        private void Draw()
        {
            var card = this.Deck.Draw();
            this.DrawnCards.Add(card);
        }

        private void Shuffle()
        {
            this.Deck.Shuffle();
        }

        public void DisplayError(string message)
        {
            this.View.DisplayError(message);
        }

        public void DisplayError(Exception ex)
        {
            this.View.DisplayError(ex);
        }

        public void OnReset()
        {
            try
            {
                this.Reset();
                this.DrawCommand.OnExecuteChanged();
                this.ShuffleCommand.OnExecuteChanged();
            }
            catch (InvalidDeckOperationException ex)
            {
                this.DisplayError(ex.Message);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        public void OnDraw()
        {
            try
            {
                this.Draw();
                this.ShuffleCommand.OnExecuteChanged();
            }
            catch (InvalidDeckOperationException ex)
            {
                this.DisplayError(ex.Message);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        public bool CanDraw()
        {
            return !this.Deck.IsEmpty();
        }

        public void OnShuffle()
        {
            try
            {
                this.Shuffle();
                this.DrawCommand.OnExecuteChanged();
                this.ShuffleCommand.OnExecuteChanged();
            }
            catch (InvalidDeckOperationException ex)
            {
                this.DisplayError(ex.Message);
            }
            catch (System.Exception ex)
            {
                this.DisplayError(ex);
            }
        }

        public bool CanShuffle()
        {
            return this.SelectedShuffleProvider != null && this.Deck.IsFull();
        }
    }
}
