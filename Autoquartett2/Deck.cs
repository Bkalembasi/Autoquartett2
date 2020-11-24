using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoquartett2
{
    class Deck
    {
        /**
         * Liste, die 32 Objekte des Typs Car enthält 
         */
        private LinkedList<Car> cars = new LinkedList<Car>();

        public Deck()
        {
            InitateCards();
        }

        /*
         *Liest einzelnen Karten aus einer JSON Datei aus und speichert sie als Objekte des Typs Car 
         */
        private void InitateCards()
        {
            string jsonString;
            string workingDirectory = Environment.CurrentDirectory;
            string filePath = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string fileName = "CarList.json";




            jsonString = File.ReadAllText(Path.Combine(filePath, fileName));
            Newtonsoft.Json.Linq.JArray objects = (Newtonsoft.Json.Linq.JArray)JsonConvert.DeserializeObject(jsonString);
            foreach (Newtonsoft.Json.Linq.JToken jobj in objects)
            {
                Car car = jobj.ToObject<Car>();
                cars.AddLast(car);
            }
        }

        /*
         *Mischt die Karten des Decks 
        */
        public void ShuffleCars()
        {
            List<Car> tempCars = new List<Car>();
            for(int i = 0; i < cars.Count; i++)
            {
                tempCars[i] = cars.ElementAt(i);
            }
            Random rng = new Random();
            for (int i = cars.Count; i > 0; i--)
            {
                SwapCard(tempCars, 0, rng.Next(0, i));
            }
            cars.Clear();
            for(int i = 0; i < tempCars.Count; i++)
            {
                cars.AddFirst(tempCars[i]);
            }
        }

        /*
         * Führt einen Dreieckstausch aus
         */
        private void SwapCard(List<Car> tempCars, int i, int j)
        {
            Car temp = tempCars[i];
            tempCars[i] = tempCars[j];
            tempCars[j] = temp;
        }

        /*
         * Teilt alle Karten gleichmäßig auf die teilnehmenden Spieler auf. Lässt sie Anzahl an Karten nicht glatt durch die Spieleranzahl teilen,
         * werden wird der nächst kleinere Teiler verwendet und die übrigen Karten ignoriert.
         */
        public bool DistributeCars(List<Player> playerList)
            {
            int toMuch = cars.Count % playerList.Count();

            for (int i = 0; i < (playerList.Count() - toMuch); i++)
            {
                int playerNumber = i % playerList.Count();
                playerList.ElementAt(playerNumber).AddCar(cars.ElementAt(i));
            }

            return true;
        }
    }
}