using System.ComponentModel;
using System.IO;

namespace GwintCrossPlatform
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

    public class Card
    {
        public int Strength { get; set; }
        public CardRow Row { get; set; }
        public CardEffect Effect { get; set; }
        public bool Golden { get; set; }
        public string FullName => $"{Name} [{Strength}]";
        public string Name { get; set; }

        //konstruktor
        public Card(string name, int strength)
        {
            Name = name;
            Strength = strength;
        }

        public Card()
        {
            Name = "Brak";
        }

        public void Update(string name, int strength, CardRow row, CardEffect effect, bool golden)
        {
            Name = name;
            Strength = strength;
            Row = row;
            Effect = effect;
            Golden = golden;
        }
    }
}
