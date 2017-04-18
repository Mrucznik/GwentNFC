using System.ComponentModel;
using System.IO;

namespace Edytor_kart
{
    public enum CardRow
    {
        None,
        King,
        CloseCombat,
        LognRange,
        Siege,
        All
    }

    public enum CardEffect
    {
        None,
        RogDowodcy,
        Pozoga,
        Manekin,
        Mroz,
        Mgla, //FlotestKrol
        Deszcz, //EmhyrJez
        CzysteNiebo, //FoltestDowodca
        Braterstwo,
        Szpieg,
        Zrecznosc,
        Medyk,
        Wiez,
        WysokieMorale,
        PozogaSmoka,
        RogJaskra,
        //foltesty
        FoltestWladca,
        FoltestZdobywca,
        FlotestSyn,
        //emhyry
        EmhyrNajezdzca,
        EmhyrPlomien,
        EmhyrPan,
        EmhyrCesarz
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

        public string generateSqlInsertQuery()
        {
            return $"INSERT INTO `cards` (`title`, `strength`, `row`, `golden`, `cardEffect`) VALUES ('{_name}', '{_strength}', '{Row}', '{(Golden?1:0)}', '{Effect}');";
        }
    }
}
