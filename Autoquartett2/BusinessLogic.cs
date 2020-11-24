using System;
using System.Collections.Generic;
using System.Text;

namespace Autoquartett2
{
    public class BusinessLogic
    {
        private int playerCount;
        private int computerCount;
        private bool computer;
        private List<Player> playerList = new List<Player>();

        public void SetPlayerCount(int ParamPlayerCount)
        {
            playerCount = ParamPlayerCount;
        }
        public int GetPlayerCount()
        {
            return playerCount;
        }
        public void SetComputerCount(int ParamComputerCount)
        {
            computerCount = ParamComputerCount;
        }
        public int GetComputerCount()
        {
            return computerCount;
        }
        public void SetComputer(bool ParamComputer)
        {
            computer = ParamComputer;
        }
        public bool GetComputer()
        {
            return computer;
        }
        public void StartGame()
        {
            int startX = 2;
            int startY = 1;

            GUI gui = new GUI();
            gui.WriteWindowBorder();
            gui.SetWindowCursorCoords(startX, startY);

            Console.Write("Mit wie vielen Spielern soll gespielt werden?");

            startY++;

            gui.SetWindowCursorCoords(startX, startY);
            playerCount = Convert.ToInt32(Console.ReadLine());

            if (playerCount < 4)
            {
                startY++;
                gui.SetWindowCursorCoords(startX, startY);
                Console.Write("Soll mit Computern aufgefüllt werden? (y/n)");

                startY++;
                gui.SetWindowCursorCoords(startX, startY);
                if("y".Equals(Console.ReadLine().ToLower()))
                {
                    computerCount = 4 - playerCount;
                    computer = true;
                }
            }
            
            for(int i = 0; i < 4; i++)
            {
                Player player = new Player();
                player.SetInGame(true);
                if(computer && playerCount >= (i-1))
                {
                    player.setKI(true);
                } else
                {
                    player.setKI(false);
                }
                playerList.Add(player);
     
            }
            Deck deck = new Deck();
            deck.ShuffleCars();
            deck.DistributeCars(playerList);

            int playersInGame = playerCount + computerCount;
            int playerTurn = 0;
            while(playersInGame > 1)
            {
                Player player = playerList[playerTurn];
                if (player.IsInGame())
                {
                    Console.Clear();
                    startX = 2;
                    startY = 1;
                    gui.SetWindowCursorCoords(startX, startY);

                    Console.Write("Spieler " + (playerTurn+1) + " ist am Zug.");
                    startY++;
                    gui.SetWindowCursorCoords(startX, startY);

                    if (player.GetCarCount() > 0)
                    {
                        Car car = (Car)player.GetFirstCard();
                        gui.ShowCard(car);
                        startY++;
                        gui.SetWindowCursorCoords(startX, startY);
                        Console.Write("Welcher Wert soll verglichen werden?");

                        startY++;
                        gui.SetWindowCursorCoords(startX, startY);

                        string toCompare = Console.ReadLine();

                    } else
                    {
                        player.SetInGame(false);
                    }              
                }
                playerTurn++;

                if (playerTurn > playersInGame)
                {
                    playerTurn = 0;
                }

            }
        }



        private int StartTurn()
        {
            return 1;
        }
        public int GetWinner()
        {
            return 1;
        }
        public string GetPlayerInput()
        {
            return Console.ReadLine();
        }              
    }
}
