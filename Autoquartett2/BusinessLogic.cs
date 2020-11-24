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
