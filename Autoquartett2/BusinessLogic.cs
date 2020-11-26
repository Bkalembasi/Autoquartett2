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

        public double GetInput(List<Car> carList)
        {
            bool higherNumber = true;
            string playerInput;
            int stringValue;

            playerInput = Console.ReadLine();

            switch (playerInput)
            {
                case "1":
                case "beschleunigung":
                    higherNumber = false;
                    stringValue = 1;
                    break;

                case "2":
                case "hubraum":
                    stringValue = 2;
                    break;

                case "3":
                case "verbrauch":
                    higherNumber = false;
                    stringValue = 3;
                    break;

                case "4":
                case "geschwindigkeit":
                    stringValue = 4;
                    break;

                case "5":
                case "leistung":
                    stringValue = 5;
                    break;

                case "6":
                case "zylinder":
                    stringValue = 6;
                    break;

                default:
                    stringValue = 0;
                    break;
            }
            return FillArray(stringValue, higherNumber, carList);
            

        }
        public double FillArray(int value, bool higherNumber, List<Car> carList) 
        {
            double[] values = new double[4];
            for (int j = 0; j < carList.Count; j++) {
                switch (value)
                {
                    case 1:
                        values[j] = carList[j].GetAcceleration();
                        break;

                    case 2:
                        values[j] = carList[j].GetPiston();
                        break;

                    case 3:
                        values[j] = carList[j].GetConsumption();
                        break;

                    case 4:
                        values[j] = carList[j].GetKmPerH();
                        break;

                    case 5:
                        values[j] = carList[j].GetPs();
                        break;

                    case 6:
                        values[j] = carList[j].GetPiston();
                        break;
                }
            }
            double erg = Car.Comparison(values, higherNumber);

            return erg;
        }              
    }
}
