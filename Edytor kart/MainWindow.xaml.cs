using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml.Serialization;


namespace Edytor_kart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [XmlRoot("Karty")]
    public partial class MainWindow : Window
    {
        [XmlArray("ListowanieKart")]
        [XmlArrayItem("Karta", typeof(Card))]
        private ObservableCollection<Card> cards = new ObservableCollection<Card>();

        public MainWindow()
        {
            InitializeComponent();

            DeserializeData();

            LbCards.ItemsSource = cards;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            SerializeData();
        }

        private void SerializeData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(cards.GetType());
                using (TextWriter textWriter = new StreamWriter("cards.xml"))
                {
                    serializer.Serialize(textWriter, cards);
                    textWriter.Close();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void DeserializeData()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(cards.GetType());
                using (TextReader textReader = new StreamReader("cards.xml"))
                {
                    cards = (ObservableCollection<Card>)serializer.Deserialize(textReader);
                    textReader.Close();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            var card = new Card();
            cards.Add(card);
            if(Autoedit.IsChecked??false)
                ShowEditWindow(card);
        }

        private void CardInfo_Click(object sender, RoutedEventArgs e)
        {
            var card = GetCurrnetCard();
            if (card != null)
                ShowInfoWindow(card);
        }

        private void ChangeCard_Click(object sender, RoutedEventArgs e)
        {
            var card = GetCurrnetCard();
            if (card != null)
                ShowEditWindow(card);
        }

        private void DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            var card = GetCurrnetCard();
            if (card != null)
                cards.Remove(card);
        }

        private Card GetCurrnetCard() => LbCards.SelectedItem as Card;

        private void ShowInfoWindow(Card card)
        {
            EditWindow window = new EditWindow(card, false);
            window.Show();
        }

        private void ShowEditWindow(Card card)
        {
            EditWindow window = new EditWindow(card);
            window.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SerializeData();
        }
    }
}
