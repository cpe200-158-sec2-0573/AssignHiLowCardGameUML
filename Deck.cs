using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Deck
    {
        public List<Card> card;

        public Deck()
        {
            card = new List<Card>() ;
        }

        public Deck(int value = 13 , int suit = 4 ) : this()
        {
            for (int i = 0; i < value; i++)
            {
                for (int j = 0; j < suit; j++)

                    card.Add(new Card { Value = i+1,Suit = j+1 });
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for(int first = 0; first < card.Count; first++)
            {
                var second = random.Next(first, card.Count);
                var tmp = card[first];
                card[first] = card[second];
                card[second] = tmp;
            }
        }

        public void ViewCardinDeck()
        {
            foreach (Card cardd in this.card)
            {
                Console.WriteLine(cardd);
            }
        }

    }
}
