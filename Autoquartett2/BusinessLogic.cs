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
            int playerCount;

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
                Console.ReadLine();
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
