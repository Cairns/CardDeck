using CardDeck.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardDeck.UI
{
    /// <summary>
    /// Interaction logic for DeckView.xaml
    /// </summary>
    public partial class DeckView : UserControl, IViewBase
    {
        public DeckView()
        {
            InitializeComponent();

            this.DataContext = new DeckViewModel(this);
        }

        public void DisplayError(string message)
        {
            MessageBox.Show(
                messageBoxText: message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }

        public void DisplayError(Exception ex)
        {
            MessageBox.Show(
                messageBoxText: ex.Message,
                caption: "Error",
                button: MessageBoxButton.OK,
                icon: MessageBoxImage.Error
                );
        }
    }
}
