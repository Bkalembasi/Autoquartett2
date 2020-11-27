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

        /**
         * Setter für die Spieler Anzahl 
         */
        public void SetPlayerCount(int ParamPlayerCount)
        {
            playerCount = ParamPlayerCount;
        }

        /**
         * Getter für die Spieler Anzahl
         */
        public int GetPlayerCount()
        {
            return playerCount;
        }
        /**
         * Setter Computer Anzahl
         */
        public void SetComputerCount(int ParamComputerCount)
        {
            computerCount = ParamComputerCount;
        }
        /**
         * Getter Computer Anzahl
         */
        public int GetComputerCount()
        {
            return computerCount;
        }
        /**
         * Setzt einen boolean der angibt ob es KIs  gibt
         */
        public void SetComputer(bool ParamComputer)
        {
            computer = ParamComputer;
        }
        /**
         * Getter ob Computer vorhanden sind
         */
        public bool GetComputer()
        {
            return computer;
        }
        public void StartGame()
        {
            //Cursor Koordinaten
            int startX;
            int startY;

            //Oberflächen Objekt initialisiert, Rand erstellt
            GUI gui = new GUI();

            do
            {
                startX = 2;
                startY = 1;
                Console.Clear();

                //Bildschirmrand erstellung
                gui.WriteWindowBorder();
                gui.SetWindowCursorCoords(startX, startY);

                Console.Write("Mit wie vielen Spielern soll gespielt werden? (2-4)");

                startY++;

                gui.SetWindowCursorCoords(startX, startY);
                playerCount = Convert.ToInt32(Console.ReadLine());

                //Gibt der User mehr als 4 User an wird die Eingabe wiederholt
            } while (playerCount > 4);

            //Sind die Spieler weniger als 4 bekommt der Benutzer die Option mit Computern zu spielen
            if (playerCount < 4)
            {
                startY++;
                gui.SetWindowCursorCoords(startX, startY);
                Console.Write("Soll mit Computern aufgefüllt werden? (y/n)");

                startY++;
                gui.SetWindowCursorCoords(startX, startY);

                //Computer Einstellung
                if ("y".Equals(Console.ReadLine().ToLower()))
                {
                    computerCount = 4 - playerCount;
                    computer = true;
                }
            }

            //Spieler Liste
            CreatePlayerList();

            //Initialisierung des Decks
            Deck deck = new Deck();
            deck.ShuffleCars();
            //Verteilen der Karten
            deck.DistributeCars(this.playerList);

            PlayGame(gui);
        }
        private void CreatePlayerList()
        {
            for (int i = 0; i < this.playerCount; i++)
            {
                Player player = new Player();
                player.SetInGame(true);
                player.SetPlayerId(i + 1);

                //Setzt das Objekt Spieler als Computer fest
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
            Player player = new Player();

            gui.ReloadWindowWithBorder();

            //So lange mehr als ein Spieler im Spiel ist wird das Spiel fortgesetzt
            while (playersInGame > 1)
            {
                player = playerList[playerTurn];
                //Prüft ob der Spieler noch im spiel ist
                if (player.IsInGame())
                {
                    bool ingame = StartTurn(gui, player);

                    //Entfernt den Spieler aus der Liste und redurziert die Spieler Anzahl
                    if (!ingame)
                    {
                        this.playerList.Remove(player);
                        playersInGame--;
                    }
                }
                playerTurn++;

                //Resetten des Zug index
                if (playerTurn >= playersInGame)
                {
                    playerTurn = 0;
                }
            }
            player = this.playerList[0];
            //Spiel Ende
            EndGame(gui , player);
        }

        private void EndGame(GUI gui, Player player)
        {
            int winnerIndex = GetWinner();
            this.playerList[winnerIndex].AddWin();
            gui.ReloadWindowWithBorder();

            int y = 1;
            gui.SetWindowCursorCoords(2, 1);
            
            Console.Write("Spieler " + player.GetPlayerId() + " hat gewonnen");
            y++;
            gui.SetWindowCursorCoords(2, y);

            Console.Write("Neues Spiel? (y/n)");
            y++;
            gui.SetWindowCursorCoords(2, y);

            if ("y".Equals(Console.ReadLine().ToLower()))
            {
                StartGame();
            }

        }

        private bool StartTurn(GUI gui, Player player)
        {
            int y = 1;
            if (player.GetCarCount() > 0)
            {
                gui.ReloadWindowWithBorder();
                gui.SetWindowCursorCoords(2, 1);

                Console.Write("Spieler " + player.GetPlayerId() + " (Karten: " + player.GetLengthCarList() + ") ist am Zug. ");
                y++;
                gui.SetWindowCursorCoords(2, y);

                Car car = player.GetFirstCard();
                gui.ShowCard(car);
                y++;

                gui.SetWindowCursorCoords(2, y);
                gui.UserInput("Welcher Wert soll verglichen werden?");
                CompareCards(gui);
            }
            else
            {
                player.SetInGame(false);
                return false;
            }

            return true;
        }

        private void CompareCards(GUI gui)
        {
            List<Car> carsToCompare = GetCardsToCompare();
            int winnerIndex = GetInput(carsToCompare, gui);
            while (winnerIndex < 0)
            {
                List<Car> stingList = GetCardsToCompare();
                winnerIndex = GetInput(stingList, gui);

                foreach (Car car in stingList)
                {
                    carsToCompare.Add(car);
                }
            } 
            //Karten werden dem winnerIndex zugeschrieben
            foreach (Car car in carsToCompare)
            {
                this.playerList[winnerIndex].AddCar(car);
            }
        }
        /**
        * Nimmt sich die Obersten Karten von den Spielern und speichert sie in einer Liste
        */
        private List<Car> GetCardsToCompare()
        {
            List<Car> carsToCompare = new List<Car>();
            foreach (Player player in this.playerList)
            {
                if (player.GetCarCount() < 1)
                {
                    continue;
                }

                carsToCompare.Add(player.GetFirstCard());
                player.RemoveCard();
            }
            return carsToCompare;
        }
        public int GetWinner()
        {
            int playerIndex = 0;
            for(int i = 0; i < playerList.Count; i++)
            {
                Player player = this.playerList[i];
                if(player.GetCarCount() > 0 )
                {
                    playerIndex = i;
                }
            }
            return playerIndex;
        }
    
        public string GetPlayerInput()
        {
            return Console.ReadLine();
        }

        public int GetInput(List<Car> carList, GUI gui)
        {
            bool higherNumber = true;
            string playerInput;
            int stringValue;
            playerInput = Console.ReadLine().ToLower();

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
            return FillArray(stringValue, higherNumber, carList, gui);
        }
        public int FillArray(int value, bool higherNumber, List<Car> carList, GUI gui)
        {
            double[] values = new double[4];
            string stringValue = "mäh";

            for (int j = 0; j < carList.Count; j++)
            {
                switch (value)
                {
                    case 1:
                        values[j] = carList[j].GetAcceleration();
                        stringValue = "Beschleunigung";
                        break;

                    case 2:
                        values[j] = carList[j].GetCcm();
                        stringValue = "Ccm";
                        break;

                    case 3:
                        values[j] = carList[j].GetConsumption();
                        stringValue = "Verbrauch";
                        break;

                    case 4:
                        values[j] = carList[j].GetKmPerH();
                        stringValue = "Geschwindigkeit";
                        break;

                    case 5:
                        values[j] = carList[j].GetPs();
                        stringValue = "Leistung";
                        break;

                    case 6:
                        values[j] = carList[j].GetPiston();
                        stringValue = "Zylinder";
                        break;
                }
            }

            int erg = Car.Comparison(values, higherNumber);
            WriteValues(stringValue, values, carList, gui, erg);

            return erg;
        }

        public void WriteValues(string stringValue, double[] values, List<Car> carList, GUI gui, int winner)
        {
            int xKoord = Convert.ToInt32(Console.WindowWidth * 0.7);
            int yKoord = 2;

            for (int j = 0; j < carList.Count; j++)
            {
                gui.SetWindowCursorCoords(xKoord, yKoord);
                Console.Write("Spieler " + (j + 1) + ": " + stringValue + " " + values[j]);
                yKoord++;
            }

            gui.SetWindowCursorCoords(xKoord, yKoord);
            Console.Write("Sieger: Spieler " + (winner + 1));

            Console.ReadLine();
        }
    }
}
    