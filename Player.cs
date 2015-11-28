using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Player
    {
        protected string _name;
        protected Deck _deckPlayer;
        protected int _order;
        protected int _count;

        public string Name
        {
            get { return _name; }
            set { _name = value ; }
        }

        public Deck DeckPlayer
        {
            get { return _deckPlayer ; }
            set { _deckPlayer = value ; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value ; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Player(int order = 0 , string name = "xxxxxx")
        {
            DeckPlayer = new Deck();
            Count = 0;
            Name = name ;
            Order = order;
        }

        public void ShowPlayerCard()
        {
            Console.WriteLine(" " + Name + " : " + DeckPlayer.card.Count + " playing card(s) " + Count + "getting card ");
        }
    }
}
