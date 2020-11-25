﻿using System;
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

            CreatePlayerList();

            Deck deck = new Deck();
            deck.ShuffleCars();
            deck.DistributeCars(this.playerList);

            PlayGame(gui);
        }
        private void CreatePlayerList()
        {
            for (int i = 0; i < 4; i++)
            {
                Player player = new Player();
                player.SetInGame(true);
                if (this.computer && this.playerCount > i)
                {
                    player.setKI(true);
                }
                else
                {
                    player.setKI(false);
                }
                playerList.Add(player);
            }
        }

        private void PlayGame(GUI gui)
        {
            int playersInGame = playerCount + computerCount;
            int playerTurn = 0;

            gui.ReloadWindowWithBorder();

            while (playersInGame > 1)
            {
                Player player = playerList[playerTurn];
                if (player.IsInGame())
                {
                    bool ingame = StartTurn(gui, player, playerTurn+1);

                    if (!ingame)
                    {
                        this.playerList.Remove(player);
                        playersInGame--;
                    }
                }
                playerTurn++;

                if (playerTurn > playersInGame)
                {
                    playerTurn = 0;
                }

            }
        }

        private bool StartTurn(GUI gui, Player player, int playerId)
        {
            int y = 1;
            if (player.GetCarCount() > 0)
            {
                gui.SetWindowCursorCoords(2, 1);

                Console.Write("Spieler " + playerId + " ist am Zug.");
                y++;
                gui.SetWindowCursorCoords(2, y);

                Car car = player.GetFirstCard();
                gui.ShowCard(car);
                y++;
                
                gui.SetWindowCursorCoords(2, y);
                gui.UserInput("Welcher Wert soll verglichen werden?");
                string toCompare = Console.ReadLine();
            }
            else
            {
                player.SetInGame(false);
                return false;
            }

            return true;
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
