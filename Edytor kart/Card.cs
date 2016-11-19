using System.ComponentModel;
using System.IO;

namespace Edytor_kart
{
    public enum CardRow
    {
        CloseCombat,
        LognRange,
        Siege
    }

    public enum CardEffect
    {
        None,
        RogDowodcy,
        Pozoga,
        ManekinDoCwiczen,
        TrzaskajacyMroz,
        GestaMgla,
        UlewnyDeszcz,
        CzysteNiebo,
        Braterstwo,
        Szpiegostwo,
        Zrecznosc,
        Zmartwychwstanie,
        Wiez,
        WysokieMorale,
        PozogaSmoka,
        RogJaskra
    }

    public class Card : INotifyPropertyChanged
    {
        private string _name;
        private int _strength;

        public int Strength
        {
            get { return _strength; }
            set
            {
                _strength = value;
                NotifyPropertyChanged("FullName");
            }
        }

        public CardRow Row { get; set; }
        public CardEffect Effect { get; set; }
        public bool Golden { get; set; }
        public string FullName => $"{_name} [{Strength}]";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("FullName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //konstruktor
        public Card(string name, int strength)
        {
            _name = name;
            _strength = strength;
        }

        public Card()
        {
            _name = "Brak";
        }

        public void Update(string name, int strength, CardRow row, CardEffect effect, bool golden)
        {
            _name = name;
            _strength = strength;
            Row = row;
            Effect = effect;
            Golden = golden;
            NotifyPropertyChanged("FullName");
        }

        public void Save(FileStream stream)
        {

        }
    }
}
