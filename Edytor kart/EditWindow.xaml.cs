using System;
using System.Windows;

namespace Edytor_kart
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private Card card;
        private bool readOnly;
        public EditWindow(Card card, bool enabled = true)
        {
            InitializeComponent();

            this.card = card;
            LoadCardData(card);
            
            readOnly = !enabled;
            if (readOnly)
            {
                MakeReadOnly();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(!readOnly)
                SaveCardData(card);
            Close();
        }

        private void LoadCardData(Card card)
        {
            Header.Text = card.FullName;
            TbCardName.Text = card.Name;
            TbCardStrength.Text = card.Strength.ToString();

            foreach (string key in Enum.GetNames(typeof(CardRow)))
            {
                CbCardRow.Items.Add(key);
            }
            CbCardRow.SelectedIndex = (int) card.Row;

            foreach (string key in Enum.GetNames(typeof(CardEffect)))
            {
                CbCardEffect.Items.Add(key);
            }
            CbCardEffect.SelectedIndex = (int) card.Effect;

            ChbCardGoldness.IsChecked = card.Golden;
        }

        private void SaveCardData(Card card)
        {
            int strength;
            int.TryParse(TbCardStrength.Text, out strength);
            card.Update(TbCardName.Text, strength, (CardRow)CbCardRow.SelectedIndex, (CardEffect)CbCardEffect.SelectedIndex, ChbCardGoldness.IsChecked??false);
        }

        private void MakeReadOnly()
        {
            TbCardName.IsEnabled = false;
            TbCardStrength.IsEnabled = false;
            CbCardEffect.IsEnabled = false;
            CbCardRow.IsEnabled = false;
            ChbCardGoldness.IsEnabled = false;
            SaveButton.Content = "Zamknij";
        }
    }
}
