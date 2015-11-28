using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(1);
            Player player2 = new Player(2);
            Control.Setting();
            Control.NewPlayer(player1, player2);
            Control.PlayerAddDeck(player1, player2);
            Console.WriteLine("GAME START!!!");

            int gamestop = 0;
            int turn = 1;
            do
            {
                Console.WriteLine("Turn : " + turn + " ");
                gamestop = Control.comparePlayerCard(player1, player2);
                player1.ShowPlayerCard();
                player2.ShowPlayerCard();
                Console.WriteLine("");
                ++turn;
            } while (gamestop != -1);

            Control.FinishGame(player1, player2);
            Console.ReadKey();
            
        }
    }
}
