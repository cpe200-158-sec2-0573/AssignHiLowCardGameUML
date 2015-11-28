using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Control
    {
         static Deck _baseDeck;
         static bool _tie = false;

        public static void Setting()
        {   
            _baseDeck = new Deck(13,4);
            _baseDeck.Shuffle();
        }
        
        public static void NewPlayer(Player player1 , Player player2,string playername1 = "xxxxxx1",string playername2 = "xxxxxx2")
        {
            Console.Write("Player1 Name : ");
            playername1 = Console.ReadLine();
            Console.Write("Player2 Name : ");
            playername2 = Console.ReadLine();
            player1.Name = playername1;
            player2.Name = playername2;
        } 

        public static void PlayerAddDeck(Player player1 , Player player2)
        {
            for(int i = 0; i < 26; i++)
            {
                player1.DeckPlayer.card.Add(_baseDeck.card[i]);
                player2.DeckPlayer.card.Add(_baseDeck.card[i + 26]);
            }
        }

        public static void PlayerWin(Player player1 , int numberOfCard = 1)
        {
            player1.Count += (numberOfCard) * 2;
            if (_tie) player1.Count += 2;

            Console.WriteLine("Wninner is " + player1.Name + " get " + (numberOfCard * 2) + " cards into his pile");
        }

        public static void PlayerTie(Player player1 , Player player2)
        {
            Console.WriteLine("This turn is Tie. System will reshuffle deck of the both players. ");
            player1.DeckPlayer.Shuffle();
            player2.DeckPlayer.Shuffle();
            _tie = true;
        }

        public static void RemovePlayerCard(Player player1 , Player player2 , int range)
        {
            int lastCard = player1.DeckPlayer.card.Count - 1;
            player1.DeckPlayer.card.RemoveRange(lastCard - range + 1, range);
            player2.DeckPlayer.card.RemoveRange(lastCard - range + 1, range);

        }

        public static int comparePlayerCard(Player player1, Player player2)
        {
            _tie = false;
            if (player1.DeckPlayer.card.Count == 0)
            {
                Console.WriteLine("No more card left form the both players.");
                return -1;
            }
            int lastCard = player1.DeckPlayer.card.Count - 1;
            int player1_last = player1.DeckPlayer.card[lastCard].Value;
            int player2_last = player2.DeckPlayer.card[lastCard].Value;
            Console.WriteLine("" + player1.Name + "has last card is " + player1.DeckPlayer.card[lastCard]);
            Console.WriteLine("" + player2.Name + "has last card is " + player2.DeckPlayer.card[lastCard]);

            if (player1.DeckPlayer.card.Count == 1 && player1.DeckPlayer.card[lastCard].Value == player2.DeckPlayer.card[lastCard].Value)
            {
                Console.WriteLine("The last card of the both players is same . (Tie)");
                return -1;
            }

            else if (player1_last == player2_last)
            {
                bool continueGame = true;
                for (int i = 0; i <= lastCard; i++)
                {
                    for (int j = 0; j <= lastCard; j++)
                    {
                        if (player1.DeckPlayer.card[i].Value > player2.DeckPlayer.card[j].Value)
                        {
                            continueGame = false;
                        }
                        else
                        {
                            continueGame = true;
                        }
                    }
                }

                if (!continueGame)
                {
                    Console.WriteLine("" + player1.Name + "card is containing pile : ");
                    player1.DeckPlayer.ViewCardinDeck();
                    Console.WriteLine("" + player2.Name + "card is containing pile : ");
                    player2.DeckPlayer.ViewCardinDeck();
                    return -1;
                }

                int numberFromLastCard = player1_last;
                if (numberFromLastCard > lastCard)
                {
                    //PlayerTie(player1, player2);
                    numberFromLastCard = lastCard;
                    // return 0;
                }

                Console.WriteLine("" + player1.Name + " has " + player1.DeckPlayer.card[numberFromLastCard]);
                Console.WriteLine("" + player2.Name + " has " + player2.DeckPlayer.card[numberFromLastCard]);
                int player1_last2 = player1.DeckPlayer.card[numberFromLastCard].Value;
                int player2_last2 = player2.DeckPlayer.card[numberFromLastCard].Value;
                if (player1_last2 < player2_last2)
                {
                    PlayerWin(player1, numberFromLastCard);
                    RemovePlayerCard(player1, player2, numberFromLastCard);
                    return 1;
                }
                else if (player1_last2 > player2_last2)
                {
                    PlayerWin(player2, numberFromLastCard);
                    RemovePlayerCard(player1, player2, numberFromLastCard);
                    return 2;
                }
                else
                {
                    PlayerTie(player1, player2);
                    return 0;
                }
            }
            else if (player1_last < player2_last) // Player 1 WIN
            {
                PlayerWin(player1);
                RemovePlayerCard(player1, player2, 1);
                return 1;
            }

            else if (player1_last > player2_last) // Player2 Win
            {
                PlayerWin(player2);
                RemovePlayerCard(player1, player2, 1);
                return 2;
            }
            return -1;
        }

        public static void FinishGame(Player player1 , Player player2)
        {
            Console.WriteLine("");
            string stringwinner = " The Winner is ";
            if (player1.Count > player2.Count)
            {
                stringwinner += player1.Name;
            }
            else if (player2.Count > player1.Count)
            {
                stringwinner += player2.Name;
            }
            else stringwinner += "no one";

            Console.WriteLine(stringwinner);
        }
     }
}
  