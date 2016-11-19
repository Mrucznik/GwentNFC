using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace Edytor_kart
{
    public enum CardRow
    {
        CloseCombat,
        LognRange,
        Siege
    }

    public class Card : INotifyPropertyChanged
    {
        private int strength;
        private CardRow row;
        private string name;

        public string FullName => $"{name} [{strength}]";
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("FullName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Card(string name)
        {
            this.name = name;
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Card> cards = new ObservableCollection<Card>();

        public MainWindow()
        {
            InitializeComponent();

            cards.Add(new Card("Geralt z Rivii"));
            cards.Add(new Card("Cirilla z Cintry"));

            LbCards.ItemsSource = cards;
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            cards.Add(new Card("Nowa karta"));
        }

        private void CardInfo_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        private void ChangeCard_Click(object sender, RoutedEventArgs e)
        {
            var card = LbCards.SelectedItem as Card;
            if (card != null)
                card.Name = "Trololo";
        }

        private void DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            var card = LbCards.SelectedItem as Card;
            if (card != null)
                cards.Remove(card);
        }
    }
}
